CREATE LOGIN spreaddbuser with password='1q2w3e4R!'
CREATE USER spreaddbuser FOR LOGIN spreaddbuser

CREATE LOGIN spreaddbtestuser with password='1q2w3e4R!'
CREATE USER spreaddbtestuser FOR LOGIN spreaddbtestuser

EXEC sp_addrolemember 'db_owner', 'spreaddbuser'

---TEST DB OLUŞTURMA YETKİSİ
GRANT CREATE ANY DATABASE TO spreaddbtestuser;