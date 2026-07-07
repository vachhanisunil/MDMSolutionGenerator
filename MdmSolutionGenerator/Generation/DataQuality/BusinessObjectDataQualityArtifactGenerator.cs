namespace MdmSolutionGenerator.Generation.DataQuality;

internal sealed class BusinessObjectDataQualityArtifactGenerator(MetadataDocument metadata, string solutionName, string rootNamespace)
{
    private readonly MetadataIntentInterpreter _interpreter = new(metadata);
    private readonly ProfilingCodeTemplateBuilder _profilingBuilder = new(rootNamespace);
    private readonly DataQualityRuleCodeTemplateBuilder _ruleBuilder = new(rootNamespace);

    public IEnumerable<GeneratedFile> Emit(BusinessObjectDefinition businessObject)
    {
        var module = $"{solutionName}.Application/Modules/{businessObject.Name}/DataQuality";
        var profilingIntents = _interpreter.GetProfilingIntents(businessObject);
        var ruleIntents = _interpreter.GetRuleIntents(businessObject);

        yield return File($"{module}/Services/{businessObject.Name}Profiler.cs", _profilingBuilder.BuildProfiler(businessObject, profilingIntents));
        yield return File($"{module}/Services/{businessObject.Name}DataQualityRuleExecutor.cs", _ruleBuilder.BuildRuleExecutor(businessObject, ruleIntents));
    }

    private static GeneratedFile File(string relativePath, string content)
        => new(relativePath.Replace('\\', '/'), content);
}
