namespace HouseSpacePlannerCommon
{
    public interface IDeploymentCatalogService
    {
        void AddXap(string uri);
        void RemoveXap(string uri);
    }
}