namespace Stoqa.Infra.ORM.EntitiesMapping.Base;

public abstract class BaseMapping(string schema)
{
    private const string SchemaDefault = "Stoqa";
    protected readonly string Schema = schema;

    protected BaseMapping() : this(SchemaDefault)
    {
    }
}