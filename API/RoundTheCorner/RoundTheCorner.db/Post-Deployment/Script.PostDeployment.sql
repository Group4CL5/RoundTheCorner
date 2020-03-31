/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\DefaultData\Cuisine.sql
:r .\DefaultData\Menu.sql
:r .\DefaultData\MenuItems.sql
:r .\DefaultData\MenuSection.sql
:r .\DefaultData\Order.sql
:r .\DefaultData\OrderItems.sql
:r .\DefaultData\Review.sql
:r .\DefaultData\User.sql
:r .\DefaultData\Vendor.sql
:r .\DefaultData\VendorEmployee.sql
:r .\DefaultData\VendorLocation.sql