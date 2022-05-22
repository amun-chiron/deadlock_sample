--CREATE TABLE Users
--(
--    Id INT IDENTITY PRIMARY KEY,
--    UserName NVARCHAR(50)
--)
--CREATE TABLE Orders
--(
--    Id INT IDENTITY PRIMARY KEY,
--    Name NVARCHAR(50)
--)

--TRUNCATE TABLE Users
--TRUNCATE TABLE Orders

--INSERT INTO Users VALUES('User 1')
--INSERT INTO Orders VALUES('Order 1')

BEGIN TRAN T1
    BEGIN
	    UPDATE Users SET UserName = 'Transaction 1 executing' 
        WHERE Id = 1

        WAITFOR DELAY '00:00:20'

        UPDATE Orders SET [Name] = 'Transaction 1 executing' 
        WHERE Id = 1
        
    END
COMMIT TRANSACTION T1

BEGIN TRAN T2
	BEGIN 
		UPDATE Orders SET [Name] = 'Transaction 2 executing' 
		WHERE Id = 1

		WAITFOR DELAY '00:00:10'

		UPDATE Users SET UserName = 'Transaction 2 executing' 
		WHERE Id = 1    
	END
COMMIT TRANSACTION T2

