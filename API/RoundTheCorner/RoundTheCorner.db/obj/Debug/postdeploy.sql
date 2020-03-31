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
Begin
Insert into TblCuisine
(CuisineName, VendorID, MenuID)
Values 
('Dominican', 1, 1)
End
BEGIN
Insert into TblMenu
(vendorID, isActive)
values
(1, 1)
END
BEGIN
Insert into TblMenuItem
(itemName, menuID, MenuSectionID, [description], picture, price)
values
('cookie', 1, 1, 'cookie monster loves this', 'cookie.jpeg', 2)
END
BEGIN
Insert into TblMenuSection
(MenuID,DisplayOrderNum)
values
(1, 1)
END
BEGIN
Insert into TblOrder
(userID, vendorId, orderDate)
values
(1, 1, '2020-03-22')
END
BEGIN
Insert into TblOrderItem
(menuItemId, price)
values
(1, 3)
END
BEGIN
Insert into TblReview
(VendorID, UserID,Rating,[Subject],Body)
values
(1, 1,4,'It was not the best', 'I wish that they cooked the steak a little less')
END
BEGIN
Insert into TblUser
(firstName,lastName,phone,email,[password],DOB, deactivated)
values
('Conner','Hando','123456789','Conner.hando@student.com','loopmaker123','1997-09-11', 0)
END
BEGIN
Insert into TblVendor
(CompanyEmail, CompanyName, inspectionDate, LicenseNumber, OwnerID, Website, bio)
values
('company@email.com', 'TopCorp','2020-04-11',123456, 1,'TopCorp.com','Were the best and no one tops us' )
END
BEGIN
Insert into TblVendorEmployee
(userID,vendorID)
values
(1, 1)
END
BEGIN
Insert into TblVendorLocation
(vendorId, [datetime],locationX,locationY)
values
(1, '2020-06-23', 3, 5)
END
GO
