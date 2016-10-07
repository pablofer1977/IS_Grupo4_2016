USE dbsSALES
GO
IF EXISTS (SELECT name FROM sysobjects 
	WHERE name = 'FN_EMail_Validar2' AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION FN_EMail_Validar2
GO
CREATE FUNCTION FN_EMail_Validar2 (@pEMail VARCHAR(255))
RETURNS BIT
AS  
BEGIN  
	DECLARE @Valido BIT
	DECLARE @EMail VARCHAR(255)
	
	SET @EMail = LTRIM(RTRIM(@pEMail))
	SET @Valido = 0
	  
	IF @EMail NOT LIKE '%@%\_%'  ESCAPE '\'
	AND @EMail NOT LIKE '%@%@%'  
	AND CHARINDEX('.@',@EMail) = 0  
	AND CHARINDEX('..',@EMail) = 0  
	AND CHARINDEX(',',@EMail) = 0  
	AND RIGHT(@EMail,1) BETWEEN 'a' AND 'z'  
	AND PATINDEX ('%[ &'',":;!+=\/()<>]%', @EMail) = 0
	AND (@EMail LIKE '%.arpa'
	OR	@EMail LIKE '%.root'
	OR	@EMail LIKE '%.aero'
	OR	@EMail LIKE '%.biz'
	OR	@EMail LIKE '%.cat'
	OR	@EMail LIKE '%.com'
	OR	@EMail LIKE '%.coop'
	OR	@EMail LIKE '%.edu'
	OR	@EMail LIKE '%.gov'
	OR	@EMail LIKE '%.info'
	OR	@EMail LIKE '%.int'
	OR	@EMail LIKE '%.jobs'
	OR	@EMail LIKE '%.mil'
	OR	@EMail LIKE '%.mobi'
	OR	@EMail LIKE '%.museum'
	OR	@EMail LIKE '%.name'
	OR	@EMail LIKE '%.net'
	OR	@EMail LIKE '%.org'
	OR	@EMail LIKE '%.pro'
	OR	@EMail LIKE '%.tel'
	OR	@EMail LIKE '%.travel'
	OR	@EMail LIKE '%.ac'
	OR	@EMail LIKE '%.ad'
	OR	@EMail LIKE '%.ae'
	OR	@EMail LIKE '%.af'
	OR	@EMail LIKE '%.ag'
	OR	@EMail LIKE '%.ai'
	OR	@EMail LIKE '%.al'
	OR	@EMail LIKE '%.am'
	OR	@EMail LIKE '%.an'
	OR	@EMail LIKE '%.ao'
	OR	@EMail LIKE '%.aq'
	OR	@EMail LIKE '%.am'
	OR	@EMail LIKE '%.ar'
	OR	@EMail LIKE '%.as'
	OR	@EMail LIKE '%.at'
	OR	@EMail LIKE '%.au'
	OR	@EMail LIKE '%.aw'
	OR	@EMail LIKE '%.ax'
	OR	@EMail LIKE '%.az'
	OR	@EMail LIKE '%.ba'
	OR	@EMail LIKE '%.bb'
	OR	@EMail LIKE '%.bd'
	OR	@EMail LIKE '%.be'
	OR	@EMail LIKE '%.bf'
	OR	@EMail LIKE '%.bg'
	OR	@EMail LIKE '%.bh'
	OR	@EMail LIKE '%.bi'
	OR	@EMail LIKE '%.bj'
	OR	@EMail LIKE '%.bm'
	OR	@EMail LIKE '%.bn'
	OR	@EMail LIKE '%.bo'
	OR	@EMail LIKE '%.br'
	OR	@EMail LIKE '%.bs'
	OR	@EMail LIKE '%.bt'
	OR	@EMail LIKE '%.bv'
	OR	@EMail LIKE '%.bw'
	OR	@EMail LIKE '%.by'
	OR	@EMail LIKE '%.bz'
	OR	@EMail LIKE '%.ca'
	OR	@EMail LIKE '%.cc'
	OR	@EMail LIKE '%.cd'
	OR	@EMail LIKE '%.cf'
	OR	@EMail LIKE '%.cg'
	OR	@EMail LIKE '%.ch'
	OR	@EMail LIKE '%.ci'
	OR	@EMail LIKE '%.ck'
	OR	@EMail LIKE '%.cl'
	OR	@EMail LIKE '%.cm'
	OR	@EMail LIKE '%.cn'
	OR	@EMail LIKE '%.co'
	OR	@EMail LIKE '%.cr'
	OR	@EMail LIKE '%.cu'
	OR	@EMail LIKE '%.cv'
	OR	@EMail LIKE '%.cx'
	OR	@EMail LIKE '%.cy'
	OR	@EMail LIKE '%.cz'
	OR	@EMail LIKE '%.de'
	OR	@EMail LIKE '%.dj'
	OR	@EMail LIKE '%.dk'
	OR	@EMail LIKE '%.dm'
	OR	@EMail LIKE '%.do'
	OR	@EMail LIKE '%.dz'
	OR	@EMail LIKE '%.ec'
	OR	@EMail LIKE '%.ee'
	OR	@EMail LIKE '%.eg'
	OR	@EMail LIKE '%.er'
	OR	@EMail LIKE '%.es'
	OR	@EMail LIKE '%.et'
	OR	@EMail LIKE '%.eu'
	OR	@EMail LIKE '%.fi'
	OR	@EMail LIKE '%.fj'
	OR	@EMail LIKE '%.fk'
	OR	@EMail LIKE '%.fm'
	OR	@EMail LIKE '%.fo'
	OR	@EMail LIKE '%.fr'
	OR	@EMail LIKE '%.ga'
	OR	@EMail LIKE '%.gb'
	OR	@EMail LIKE '%.gd'
	OR	@EMail LIKE '%.ge'
	OR	@EMail LIKE '%.gf'
	OR	@EMail LIKE '%.gg'
	OR	@EMail LIKE '%.gh'
	OR	@EMail LIKE '%.gi'
	OR	@EMail LIKE '%.gl'
	OR	@EMail LIKE '%.gm'
	OR	@EMail LIKE '%.gn'
	OR	@EMail LIKE '%.gp'
	OR	@EMail LIKE '%.gq'
	OR	@EMail LIKE '%.gr'
	OR	@EMail LIKE '%.gs'
	OR	@EMail LIKE '%.gt'
	OR	@EMail LIKE '%.gu'
	OR	@EMail LIKE '%.gw'
	OR	@EMail LIKE '%.gy'
	OR	@EMail LIKE '%.hk'
	OR	@EMail LIKE '%.hm'
	OR	@EMail LIKE '%.hn'
	OR	@EMail LIKE '%.hr'
	OR	@EMail LIKE '%.ht'
	OR	@EMail LIKE '%.hu'
	OR	@EMail LIKE '%.id'
	OR	@EMail LIKE '%.ie'
	OR	@EMail LIKE '%.il'
	OR	@EMail LIKE '%.im'
	OR	@EMail LIKE '%.in'
	OR	@EMail LIKE '%.io'
	OR	@EMail LIKE '%.iq'
	OR	@EMail LIKE '%.ir'
	OR	@EMail LIKE '%.is'
	OR	@EMail LIKE '%.it'
	OR	@EMail LIKE '%.je'
	OR	@EMail LIKE '%.jm'
	OR	@EMail LIKE '%.jo'
	OR	@EMail LIKE '%.jp'
	OR	@EMail LIKE '%.ke'
	OR	@EMail LIKE '%.kg'
	OR	@EMail LIKE '%.kh'
	OR	@EMail LIKE '%.ki'
	OR	@EMail LIKE '%.km'
	OR	@EMail LIKE '%.kn'
	OR	@EMail LIKE '%.kr'
	OR	@EMail LIKE '%.kw'
	OR	@EMail LIKE '%.ky'
	OR	@EMail LIKE '%.kz'
	OR	@EMail LIKE '%.la'
	OR	@EMail LIKE '%.lb'
	OR	@EMail LIKE '%.lc'
	OR	@EMail LIKE '%.li'
	OR	@EMail LIKE '%.lk'
	OR	@EMail LIKE '%.lr'
	OR	@EMail LIKE '%.ls'
	OR	@EMail LIKE '%.lt'
	OR	@EMail LIKE '%.lu'
	OR	@EMail LIKE '%.lv'
	OR	@EMail LIKE '%.ly'
	OR	@EMail LIKE '%.ma'
	OR	@EMail LIKE '%.mc'
	OR	@EMail LIKE '%.md'
	OR	@EMail LIKE '%.mg'
	OR	@EMail LIKE '%.mh'
	OR	@EMail LIKE '%.mk'
	OR	@EMail LIKE '%.ml'
	OR	@EMail LIKE '%.mm'
	OR	@EMail LIKE '%.mn'
	OR	@EMail LIKE '%.mo'
	OR	@EMail LIKE '%.mp'
	OR	@EMail LIKE '%.mq'
	OR	@EMail LIKE '%.mr'
	OR	@EMail LIKE '%.ms'
	OR	@EMail LIKE '%.mt'
	OR	@EMail LIKE '%.mu'
	OR	@EMail LIKE '%.mv'
	OR	@EMail LIKE '%.mw'
	OR	@EMail LIKE '%.mx'
	OR	@EMail LIKE '%.my'
	OR	@EMail LIKE '%.mz'
	OR	@EMail LIKE '%.na'
	OR	@EMail LIKE '%.nc'
	OR	@EMail LIKE '%.ne'
	OR	@EMail LIKE '%.nf'
	OR	@EMail LIKE '%.ng'
	OR	@EMail LIKE '%.ni'
	OR	@EMail LIKE '%.nl'
	OR	@EMail LIKE '%.no'
	OR	@EMail LIKE '%.np'
	OR	@EMail LIKE '%.nr'
	OR	@EMail LIKE '%.nu'
	OR	@EMail LIKE '%.nz'
	OR	@EMail LIKE '%.om'
	OR	@EMail LIKE '%.pa'
	OR	@EMail LIKE '%.pe'
	OR	@EMail LIKE '%.pf'
	OR	@EMail LIKE '%.pg'
	OR	@EMail LIKE '%.ph'
	OR	@EMail LIKE '%.pk'
	OR	@EMail LIKE '%.pl'
	OR	@EMail LIKE '%.pm'
	OR	@EMail LIKE '%.pn'
	OR	@EMail LIKE '%.pr'
	OR	@EMail LIKE '%.ps'
	OR	@EMail LIKE '%.pt'
	OR	@EMail LIKE '%.pw'
	OR	@EMail LIKE '%.py'
	OR	@EMail LIKE '%.qa'
	OR	@EMail LIKE '%.re'
	OR	@EMail LIKE '%.ro'
	OR	@EMail LIKE '%.ru'
	OR	@EMail LIKE '%.rw'
	OR	@EMail LIKE '%.sa'
	OR	@EMail LIKE '%.sb'
	OR	@EMail LIKE '%.sc'
	OR	@EMail LIKE '%.sd'
	OR	@EMail LIKE '%.se'
	OR	@EMail LIKE '%.sg'
	OR	@EMail LIKE '%.sh'
	OR	@EMail LIKE '%.si'
	OR	@EMail LIKE '%.sj'
	OR	@EMail LIKE '%.sk'
	OR	@EMail LIKE '%.sl'
	OR	@EMail LIKE '%.sm'
	OR	@EMail LIKE '%.sn'
	OR	@EMail LIKE '%.so'
	OR	@EMail LIKE '%.sr'
	OR	@EMail LIKE '%.st'
	OR	@EMail LIKE '%.su'
	OR	@EMail LIKE '%.sv'
	OR	@EMail LIKE '%.sy'
	OR	@EMail LIKE '%.sz'
	OR	@EMail LIKE '%.tc'
	OR	@EMail LIKE '%.td'
	OR	@EMail LIKE '%.tf'
	OR	@EMail LIKE '%.tg'
	OR	@EMail LIKE '%.th'
	OR	@EMail LIKE '%.tj'
	OR	@EMail LIKE '%.tk'
	OR	@EMail LIKE '%.tl'
	OR	@EMail LIKE '%.tm'
	OR	@EMail LIKE '%.tn'
	OR	@EMail LIKE '%.to'
	OR	@EMail LIKE '%.tp'
	OR	@EMail LIKE '%.tr'
	OR	@EMail LIKE '%.tt'
	OR	@EMail LIKE '%.tv'
	OR	@EMail LIKE '%.tw'
	OR	@EMail LIKE '%.tz'
	OR	@EMail LIKE '%.ua'
	OR	@EMail LIKE '%.ug'
	OR	@EMail LIKE '%.uk'
	OR	@EMail LIKE '%.um'
	OR	@EMail LIKE '%.us'
	OR	@EMail LIKE '%.uy'
	OR	@EMail LIKE '%.uz'
	OR	@EMail LIKE '%.va'
	OR	@EMail LIKE '%.vc'
	OR	@EMail LIKE '%.ve'
	OR	@EMail LIKE '%.vg'
	OR	@EMail LIKE '%.vi'
	OR	@EMail LIKE '%.vn'
	OR	@EMail LIKE '%.vu'
	OR	@EMail LIKE '%.wf'
	OR	@EMail LIKE '%.ws'
	OR	@EMail LIKE '%.ye'
	OR	@EMail LIKE '%.yt'
	OR	@EMail LIKE '%.yu'
	OR	@EMail LIKE '%.za'
	OR	@EMail LIKE '%.zm'
	OR	@EMail LIKE '%.zw')
      
		SET @Valido = 1  
               
	IF @EMail LIKE '%._' 
		SET @Valido = 0

	RETURN @Valido
END
GO