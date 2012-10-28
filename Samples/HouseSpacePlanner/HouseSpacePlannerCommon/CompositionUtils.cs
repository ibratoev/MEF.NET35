
namespace HouseSpacePlanner
{
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;

    public static class CompositionUtils
    {
        /*
        public static ComposablePart AddSatisfiedExportedValue(this CompositionContainer container, string contractName, object o)
        {
            container.SatisfyImportsOnce(o);
            CompositionBatch batch = new CompositionBatch();
            var addedPart = batch.AddExportedValue(contractName, o);
            container.Compose(batch);
            return addedPart;
        }
         * */


    }
}
