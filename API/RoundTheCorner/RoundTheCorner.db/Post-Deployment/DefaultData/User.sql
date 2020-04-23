BEGIN
Insert into TblUser
(firstName,lastName,phone,email,[password],DOB, deactivated, [Admin])
values
('Conner','Hando','123456789','Conner.hando@student.com','loopmaker123','1997-09-11', 0, 0),
('Test','Account','123456789','test@test.com','qUqP5cyxm6YcTAhz05Hph5gvu9M=','1997-09-11', 0, 1)
END