namespace DbUpdater;




public class Migrator
{
    //TODO: Determine if I even like this approach(I don't)
    // SQL Files:
    //  - Create Migration History Table
    //  -- Logic added to only create if table doesn't exist
    //  - Get Migration History
    //  - Update Migration History 


    // C# Logic:
    //  - Check Migration History Table status 
    //  -- execute Create Migration History Table
    //  - Check Migration History 
    //  -- If there is history that exists without a corresponding sql script 
    //  --- Remove 
}
