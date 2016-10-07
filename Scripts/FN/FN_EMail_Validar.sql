USE dbsSGD
GO

IF EXISTS (SELECT name FROM sysobjects 
	WHERE name = 'FN_EMail_Validar' AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION FN_EMail_Validar
GO

CREATE FUNCTION FN_EMail_Validar (
 @email VARCHAR(255))

RETURNS VARCHAR(255)  
as  
BEGIN  
     Declare @valid bit  
     Declare @domain as nvarchar(256)
     Declare @str1 Varchar(128)
  Declare @i int
  
     IF @email IS NOT NULL   
    SET @email = REPLACE(@email,CHAR(10),'')
    SET @email = REPLACE(@email,CHAR(13),'')
    SET @email = REPLACE(@email,';','')
          SET @email = LOWER(@email)
          Set @email = LTRIM(RTRIM(@email))
          While (CHARINDEX('  ',@email,0) <> 0)
   Begin
    Set @email = REPLACE(@email,'  ','')
   Continue
    End  
    Set @email = LTRIM(RTRIM(@email))
          SET @valid = 0  
          --IF @email like '[a-z,0-9,_,-]%@[a-z,0-9,_,-]%.[a-z][a-z]%'  
          If  Patindex('[a-z,0-9,_,-]%@[a-z,0-9,-]%.[a-z][a-z]%', @email)=1  
    AND @email Not Like '%@%\_%'  ESCAPE '\'
             AND @email NOT like '%@%@%'  
             AND CHARINDEX('.@',@email) = 0  
             AND CHARINDEX('..',@email) = 0  
             AND CHARINDEX(',',@email) = 0  
             AND RIGHT(@email,1) between 'a' AND 'z'  
             And Patindex ('%[ &'',":;!+=\/()<>]%', @email) = 0
               SET @valid=1  
     If @email like '%._'
  Set @valid = 0
     If @valid = 0
     Begin
  Set @email = ''
     End
     
     --Se comprueba el dominio.
     
     If @email <> ''
     Begin
   Set @str1 = ''
   Set @i = 48
   While @i <= 57
   Begin
    Set @str1 = @str1 + '|' + Char(@i)
    Set @i = @i + 1
   End

    Set @i = 97
   While @i <= 122
   Begin
    Set @str1 = @str1 + '|' + Char(@i)
    Set @i = @i + 1
   End    
     
   Set @str1 = @str1 + '|.'
   Set @str1 = @str1 + '|-'
      
   Set @domain = RIGHT(@email,LEN(@email)-CHARINDEX('@',@email))
   
   If @domain Like '%[^' + @str1 + ']%' escape '|'
   Begin
   Set @email = '' 
   End
   
  End
     
     Return @email
END
GO