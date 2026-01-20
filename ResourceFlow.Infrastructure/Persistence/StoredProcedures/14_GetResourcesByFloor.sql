/*
==========================================================================================
Author:        Rinshad
Created On:    2026-01-07
Description:   Fetches all active resources for a specific floor to be displayed on the canvas.

Modified By:   
Modified On:   
Change Log:    

------------------------------------------------------------------------------------------
Execute Command (Example):
EXEC sp_GetResourcesByFloor @FloorId = 1
==========================================================================================
*/

CREATE OR ALTER  PROCEDURE sp_GetResourcesByFloor
    @FloorId INT
AS
BEGIN
    -- Improves performance by stopping success messages
    SET NOCOUNT ON;

    SELECT 
        Id, 
        ResourceTypeId, 
        X, 
        Y, 
        Width, 
        Height, 
        Rotation, 
        MetadataJson
    FROM Resources 
    WHERE FloorId = @FloorId 
      AND IsDeleted = 0;
END
GO
