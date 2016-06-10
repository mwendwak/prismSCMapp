namespace com.kinetics.prism.SyncManager
{
    public class SyncOrMaster
    {
        //CALL ALL METHODS TO ORCHESTRATE THE SYNC PROCESS

        public void SyncOrchestra()
        {
            //CALL ALL METHODS THAT PERFORM SYNCS
                //for products
                    SyncProduct syncProduct = new SyncProduct();
                    syncProduct.GetSvrProducts();
                //products
        }
    }
}