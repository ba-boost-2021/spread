CREATE LOGIN spreaddbuser with password='1q2w3e4R!'

CREATE USER spreaddbuser FOR LOGIN spreaddbuser

EXEC sp_addrolemember 'db_owner', 'spreaddbuser'