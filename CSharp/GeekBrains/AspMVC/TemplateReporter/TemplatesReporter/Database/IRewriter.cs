namespace TemplatesReporter.Database;

public interface IRewriter<in TData, in TRewritable>
{
    void Rewrite(TData data, TRewritable rewritable);
}