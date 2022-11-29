DROP DATABASE JOB;
CREATE DATABASE JOB;
USE JOB;

CREATE TABLE ORGANIZATION(
		NAME    			VARCHAR(100)   	,
		CONSTRAINT pk_ORGANIZATION PRIMARY KEY(NAME)
);
INSERT INTO ORGANIZATION(NAME) VALUES('DAI HOC CAN THO');
INSERT INTO ORGANIZATION(NAME) VALUES('KHOA CONG NGHE');
INSERT INTO ORGANIZATION(NAME) VALUES('KHOA CONG NGHE THONG TIN VA TRUYEN THONG');
INSERT INTO ORGANIZATION(NAME) VALUES('KHOA KINH TE');
INSERT INTO ORGANIZATION(NAME) VALUES('KHOA XA HOI');

CREATE TABLE ORGANIZATION_POSITION(
		ORGANIZATION_NAME   VARCHAR(100) 	    ,
		NAME    			VARCHAR(100)   		,
		CONSTRAINT fk_ORGANIZATION_POSITION FOREIGN KEY (ORGANIZATION_NAME) REFERENCES ORGANIZATION(NAME) ON DELETE CASCADE,	
		CONSTRAINT pk_ORGANIZATION_POSITION PRIMARY KEY(ORGANIZATION_NAME, NAME)
);
INSERT INTO ORGANIZATION_POSITION(ORGANIZATION_NAME, NAME) VALUES('DAI HOC CAN THO', 'HIEU TRUONG');
INSERT INTO ORGANIZATION_POSITION(ORGANIZATION_NAME, NAME) VALUES('DAI HOC CAN THO', 'HIEU PHO');
INSERT INTO ORGANIZATION_POSITION(ORGANIZATION_NAME, NAME) VALUES('KHOA CONG NGHE', 'TRUONG KHOA');
INSERT INTO ORGANIZATION_POSITION(ORGANIZATION_NAME, NAME) VALUES('KHOA CONG NGHE', 'PHO KHOA');
INSERT INTO ORGANIZATION_POSITION(ORGANIZATION_NAME, NAME) VALUES('KHOA CONG NGHE THONG TIN VA TRUYEN THONG', 'TRUONG KHOA');
INSERT INTO ORGANIZATION_POSITION(ORGANIZATION_NAME, NAME) VALUES('KHOA CONG NGHE THONG TIN VA TRUYEN THONG', 'PHO KHOA');
INSERT INTO ORGANIZATION_POSITION(ORGANIZATION_NAME, NAME) VALUES('KHOA KINH TE', 'TRUONG KHOA');
INSERT INTO ORGANIZATION_POSITION(ORGANIZATION_NAME, NAME) VALUES('KHOA KINH TE', 'PHO KHOA');
INSERT INTO ORGANIZATION_POSITION(ORGANIZATION_NAME, NAME) VALUES('KHOA XA HOI', 'TRUONG KHOA');
INSERT INTO ORGANIZATION_POSITION(ORGANIZATION_NAME, NAME) VALUES('KHOA XA HOI', 'PHO KHOA');

CREATE TABLE ADMIN(
		ID           		INT 	     		AUTO_INCREMENT,
		NAME    			VARCHAR(100)   		NOT NULL,
		GENDER				VARCHAR(30)			NOT NULL,
		D_O_B       		VARCHAR(100)    	NOT NULL,
		PHONE				VARCHAR(10)			NOT NULL,
		ADDRESS				VARCHAR(200)		NOT NULL,
		ORGANIZATION		VARCHAR(100)		NOT NULL,
		POSITION			VARCHAR(100)		NOT NULL,
		AVATAR				LONGBLOB,
		EMAIL				VARCHAR(50)			NOT NULL,
		USERNAME			VARCHAR(50)			UNIQUE NOT NULL,
		PASS				VARCHAR(50)			NOT NULL,
		QUESTION			VARCHAR(200)	    NOT NULL,
		ANSWER				VARCHAR(200)		NOT NULL,
		TOTAL_WORKING_HOUR	INT					NOT NULL,	
		CONSTRAINT pk_ADMIN PRIMARY KEY(ID)
);
INSERT INTO ADMIN(NAME, GENDER, D_O_B, PHONE, ADDRESS,  ORGANIZATION, POSITION, AVATAR, EMAIL, USERNAME, PASS, QUESTION, ANSWER, TOTAL_WORKING_HOUR) 
	VALUES('HUYNH HUU BAO KHOA', 'NAM', '14-11-2001', '0372753988', '2, TAN AN, THI TRAN CAI TAC, HAU GIANG','DAI HOC CAN THO', 'HIEU TRUONG', 'C:/xampp/htdocs/bank/images/avatar/1.jpg','ADMIN@GMAIL.COM', 'ADMIN', 'ADMIN',"WHAT IS YOUR FAVORITE FOOD?",'KHOA',0);

CREATE TABLE USER(
		ID           		INT 	     		AUTO_INCREMENT,
		NAME    			VARCHAR(100)   		NOT NULL,
		GENDER				VARCHAR(30)			NOT NULL,
		D_O_B       		VARCHAR(100)       	NOT NULL,
		PHONE				VARCHAR(10)			NOT NULL,
		ADDRESS				VARCHAR(200)		NOT NULL,
		ORGANIZATION		VARCHAR(50)			NOT NULL,
		POSITION			VARCHAR(50)			NOT NULL,
		AVATAR				LONGBLOB			NOT NULL,
		EMAIL				VARCHAR(50)			NOT NULL,
		USERNAME			VARCHAR(50)			UNIQUE NOT NULL,
		PASS				VARCHAR(50)			NOT NULL,
		QUESTION			VARCHAR(200)	    NOT NULL,
		ANSWER				VARCHAR(200)		NOT NULL,
		TOTAL_WORKING_HOUR	INT					NOT NULL,
		CONSTRAINT fk_USER1 FOREIGN KEY (ORGANIZATION) REFERENCES ORGANIZATION(NAME) ON DELETE CASCADE,	
		CONSTRAINT fk_USER2 FOREIGN KEY (ORGANIZATION,POSITION) REFERENCES ORGANIZATION_POSITION(ORGANIZATION_NAME,NAME) ON DELETE CASCADE,		
		CONSTRAINT pk_USER PRIMARY KEY(ID)
);
INSERT INTO USER(NAME, GENDER, D_O_B, PHONE, ADDRESS,  ORGANIZATION, POSITION, AVATAR, EMAIL, USERNAME, PASS, QUESTION, ANSWER, TOTAL_WORKING_HOUR) 
	VALUES('HUYNH HUU BAO KHOA', 'NAM', '14-11-2001', '0372753988', '2, TAN AN, THI TRAN CAI TAC, HAU GIANG', 'DAI HOC CAN THO', 'HIEU TRUONG', 'C:/xampp/htdocs/bank/images/avatar/1.jpg','USER1@GMAIL.COM', 'USER1', 'USER1',"WHAT IS YOUR FAVORITE FOOD?",'KHOA',243);
INSERT INTO USER(NAME, GENDER, D_O_B, PHONE, ADDRESS,  ORGANIZATION, POSITION, AVATAR, EMAIL, USERNAME, PASS, QUESTION, ANSWER, TOTAL_WORKING_HOUR) 
	VALUES('HUYNH HUU BAO KHOA', 'NAM', '14-11-2001', '0372753988', '2, TAN AN, THI TRAN CAI TAC, HAU GIANG', 'DAI HOC CAN THO', 'HIEU PHO', 'C:/xampp/htdocs/bank/images/avatar/1.jpg','USER2@GMAIL.COM', 'USER2', 'USER2',"WHAT IS YOUR FAVORITE FOOD?",'KHOA',0);
INSERT INTO USER(NAME, GENDER, D_O_B, PHONE, ADDRESS,  ORGANIZATION, POSITION, AVATAR, EMAIL, USERNAME, PASS, QUESTION, ANSWER, TOTAL_WORKING_HOUR) 
	VALUES('HUYNH HUU BAO KHOA', 'NAM', '14-11-2001', '0372753988', '2, TAN AN, THI TRAN CAI TAC, HAU GIANG', 'KHOA CONG NGHE THONG TIN VA TRUYEN THONG', 'TRUONG KHOA', 'C:/xampp/htdocs/bank/images/avatar/1.jpg','USER3@GMAIL.COM', 'USER3', 'USER3',"WHAT IS YOUR FAVORITE FOOD?",'KHOA',0);
INSERT INTO USER(NAME, GENDER, D_O_B, PHONE, ADDRESS,  ORGANIZATION, POSITION, AVATAR, EMAIL, USERNAME, PASS, QUESTION, ANSWER, TOTAL_WORKING_HOUR) 
	VALUES('HUYNH HUU BAO KHOA', 'NAM', '14-11-2001', '0372753988', '2, TAN AN, THI TRAN CAI TAC, HAU GIANG', 'KHOA CONG NGHE THONG TIN VA TRUYEN THONG', 'PHO KHOA', 'C:/xampp/htdocs/bank/images/avatar/1.jpg','USER4@GMAIL.COM', 'USER4', 'USER4',"WHAT IS YOUR FAVORITE FOOD?",'KHOA',0);

CREATE TABLE CATEGORY(
		NAME    			VARCHAR(100)   		NOT NULL,
		CONSTRAINT pk_CATEGORY PRIMARY KEY(NAME)
);
INSERT INTO CATEGORY(NAME) 
	VALUES('DAY HOC');
INSERT INTO CATEGORY(NAME) 
	VALUES('CA NHAN');
INSERT INTO CATEGORY(NAME) 
	VALUES('XA HOI');
INSERT INTO CATEGORY(NAME) 
	VALUES('DU AN');
INSERT INTO CATEGORY(NAME) 
	VALUES('LAO DONG');

CREATE TABLE JOB(
		ID           		INT 	     		AUTO_INCREMENT,
		DEPENDENCY_ID		INT					NOT NULL,
		DEPENDENCY_NAME		VARCHAR(100)		NOT NULL,
		NAME    			VARCHAR(100)   		NOT NULL,
		DESCRIPTION			VARCHAR(400)		NOT NULL,
		CATEGORY			VARCHAR(100)		NOT NULL,
		START_DATE		    VARCHAR(1000)		NOT NULL,	
		DUE_DATE			VARCHAR(100)		NOT NULL,
		END_DATE		    VARCHAR(100)		NOT NULL,	
		REQUIRED_HOUR		INT					NOT NULL,
		WORKED_HOUR			INT					NOT NULL,
		PERCENT 			INT 				NOT NULL,
		ASSIGNOR_ID			INT					NOT NULL,
		ASSIGNOR_TYPE		VARCHAR(100)		NOT NULL,
		ASSIGNOR_NAME		VARCHAR(100)		NOT NULL,
		ASSIGNEE_ID			INT					NOT NULL,
		ASSIGNEE_TYPE		VARCHAR(100)		NOT NULL,
		ASSIGNEE_NAME		VARCHAR(100)		NOT NULL,
		CONSTRAINT fk_JOB_CATEGORY FOREIGN KEY (CATEGORY) REFERENCES CATEGORY(NAME) ON DELETE CASCADE,	
		CONSTRAINT pk_JOB PRIMARY KEY(ID)
);
INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE, DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT, ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(-1, 'NONE', 'CT209H', 'DAY HOC O PHONG 110 CHO LOP CT209H', 'DAY HOC', '04-11-2022','04-03-2023','NONE',70,34,49,1,'ADMIN','HUYNH HUU BAO KHOA',
	1,'USER','HUYNH HUU BAO KHOA');
INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(-1, 'NONE', 'LAB05 CT105H', 'HOANG THANH LAB05 MON CT105H', 'DAY HOC','02-11-2022', '04-11-2022', '03-11-2022',2, 1, 100, 
  	1, 'ADMIN','HUYNH HUU BAO KHOA', 1, 'USER','HUYNH HUU BAO KHOA');
INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(-1, 'NONE', 'NLCN', 'CODE PROJECT QUAN LY CONG VIEC NLCN', 'CA NHAN', '10-07-2022', '15-12-2022', 'NONE', 300, 200, 80, 
  	1, 'ADMIN', 'HUYNH HUU BAO KHOA', 1, 'USER', 'HUYNH HUU BAO KHOA');
INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(3, 'NLCN', 'BACKEND NLCN', 'THIET KET CSDL VA SERVER', 'CA NHAN', '12-07-2022',
 '15-07-2022', '13-07-2022', 8, 6, 100, 
  1, 'ADMIN', 'HUYNH HUU BAO KHOA', 1, 'USER', 'HUYNH HUU BAO KHOA');

INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(-1, 'NONE', 'LAO DONG SAN TRUONG', 'DON VE SINH SAN TRUONG KHOA CNTT', 'XA HOI', '04-11-2022', '04-11-2022', '05-11-2022', 2, 2, 100, 
  	1, 'USER', 'HUYNH HUU BAO KHOA', 1, 'USER', 'HUYNH HUU BAO KHOA');
INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(-1, 'NONE', 'LAO DONG KHOA KINH TE', 'DON VE SINH SANH KHOA KINH TE', 'XA HOI', '14-11-2022', '14-11-2022', '14-11-2022', 2, 1, 100, 
  	1, 'USER', 'HUYNH HUU BAO KHOA', 1, 'USER', 'HUYNH HUU BAO KHOA');
INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(-1, 'NONE', 'HO TRO NGUOI NGHEO', 'THAM GIA HO TRO NGUOI NGHEO HAU GIANG, CHAU THANH', 'XA HOI', '20-01-2023', '25-01-2023', 'NONE', 20, 0, 0, 
  	1, 'USER', 'HUYNH HUU BAO KHOA', 1, 'USER', 'HUYNH HUU BAO KHOA');

INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(-1, 'NONE', 'CT209H', 'DAY HOC O PHONG 110 CHO LOP CT209H', 'DAY HOC', '04-11-2022','04-03-2023','NONE',70,34,49,1,'ADMIN','HUYNH HUU BAO KHOA',
	1,'ADMIN','HUYNH HUU BAO KHOA');
INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(-1, 'NONE', 'LAB05 CT105H', 'HOANG THANH LAB05 MON CT105H', 'DAY HOC','02-11-2022', '04-11-2022', '03-11-2022',2, 1, 100, 
  	1, 'ADMIN','HUYNH HUU BAO KHOA', 1, 'ADMIN','HUYNH HUU BAO KHOA');
INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(-1, 'NONE', 'NLCN', 'CODE PROJECT QUAN LY CONG VIEC NLCN', 'CA NHAN', '10-07-2022', '15-12-2022', 'NONE', 300, 200, 80, 
  	1, 'ADMIN', 'HUYNH HUU BAO KHOA', 1, 'ADMIN', 'HUYNH HUU BAO KHOA');
INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(3, 'NLCN', 'BACKEND NLCN', 'THIET KET CSDL VA SERVER', 'CA NHAN', '12-07-2022',
 '15-07-2022', '13-07-2022', 8, 6, 100, 
  1, 'ADMIN', 'HUYNH HUU BAO KHOA', 1, 'ADMIN', 'HUYNH HUU BAO KHOA');

INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(-1, 'NONE', 'LAO DONG SAN TRUONG', 'DON VE SINH SAN TRUONG KHOA CNTT', 'XA HOI', '04-11-2022', '04-11-2022', '05-11-2022', 2, 2, 100, 
  	1, 'ADMIN', 'HUYNH HUU BAO KHOA', 1, 'ADMIN', 'HUYNH HUU BAO KHOA');
INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(-1, 'NONE', 'LAO DONG KHOA KINH TE', 'DON VE SINH SANH KHOA KINH TE', 'XA HOI', '14-11-2022', '14-11-2022', 'NONE', 2, 0, 0, 
  	1, 'ADMIN', 'HUYNH HUU BAO KHOA', 1, 'ADMIN', 'HUYNH HUU BAO KHOA');
INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(-1, 'NONE', 'HO TRO NGUOI NGHEO', 'THAM GIA HO TRO NGUOI NGHEO HAU GIANG, CHAU THANH', 'XA HOI', '20-01-2023', '25-01-2023', 'NONE', 20, 0, 0, 
  	1, 'ADMIN', 'HUYNH HUU BAO KHOA', 1, 'ADMIN', 'HUYNH HUU BAO KHOA');
INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(-1, 'NONE', 'HO TRO NGUOI NGHEO', 'THAM GIA HO TRO NGUOI NGHEO HAU GIANG, CHAU THANH', 'XA HOI', '20-01-2022', '25-12-2022', 'NONE', 20, 0, 0, 
  	1, 'ADMIN', 'HUYNH HUU BAO KHOA', 1, 'ADMIN', 'HUYNH HUU BAO KHOA');

INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(-1, 'NONE', 'CT209H', 'DAY HOC O PHONG 110 CHO LOP CT209H', 'DAY HOC', '19-11-2022','04-03-2023','NONE',70,34,49,1,'ADMIN','HUYNH HUU BAO KHOA',
	1,'ADMIN','HUYNH HUU BAO KHOA');
INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(-1, 'NONE', 'LAB05 CT105H', 'HOANG THANH LAB05 MON CT105H', 'DAY HOC','19-11-2022', '19-11-2022', '03-11-2022',2, 1, 100, 
  	1, 'ADMIN','HUYNH HUU BAO KHOA', 1, 'ADMIN','HUYNH HUU BAO KHOA');
INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(-1, 'NONE', 'NLCN', 'CODE PROJECT QUAN LY CONG VIEC NLCN', 'CA NHAN', '19-11-2022', '15-12-2022', 'NONE', 300, 200, 80, 
  	1, 'ADMIN', 'HUYNH HUU BAO KHOA', 1, 'ADMIN', 'HUYNH HUU BAO KHOA');
INSERT INTO JOB(DEPENDENCY_ID, DEPENDENCY_NAME, NAME, DESCRIPTION, CATEGORY, START_DATE,
 DUE_DATE, END_DATE, REQUIRED_HOUR, WORKED_HOUR, PERCENT,
  ASSIGNOR_ID, ASSIGNOR_TYPE, ASSIGNOR_NAME, ASSIGNEE_ID, ASSIGNEE_TYPE, ASSIGNEE_NAME) 
	VALUES(3, 'NLCN', 'BACKEND NLCN', 'THIET KET CSDL VA SERVER', 'CA NHAN', '19-11-2022',
 '15-02-2023', '13-12-2022', 8, 6, 100, 
  1, 'ADMIN', 'HUYNH HUU BAO KHOA', 1, 'ADMIN', 'HUYNH HUU BAO KHOA');


CREATE TABLE REPORT(
		ID           		INT 	     		AUTO_INCREMENT,
		JOB_ID				INT					,
		JOB_NAME   			VARCHAR(100)   		NOT NULL,
		TILE    			VARCHAR(100)   		NOT NULL,
		DESCRIPTION			VARCHAR(400)		NOT NULL,
		CREATED_TIME		VARCHAR(200)		NOT NULL,	
		CONSTRAINT fk_REPORT FOREIGN KEY (JOB_ID) REFERENCES JOB(ID) ON DELETE CASCADE,
		CONSTRAINT pk_REPORT PRIMARY KEY(ID)
);
INSERT INTO REPORT(JOB_ID, JOB_NAME, TILE, DESCRIPTION, CREATED_TIME) VALUES(1, 'CT209H', 'BAO CAO 1 CT209H', 'DA HOAN THANH 10% CONG VIEC','18-12-2022 02:47 AM' );
INSERT INTO REPORT(JOB_ID, JOB_NAME, TILE, DESCRIPTION, CREATED_TIME) VALUES(1, 'CT209H', 'BAO CAO 2 CT209H', 'DA HOAN THANH 20% CONG VIEC','01-01-2023 03:57 PM' );
INSERT INTO REPORT(JOB_ID, JOB_NAME, TILE, DESCRIPTION, CREATED_TIME) VALUES(2, 'LAB05 CT105H', 'BAO CAO 1 LAB05 CT105H', 'DA HOAN THANH 30% CONG VIEC','03-11-2022 05:47 AM' );
INSERT INTO REPORT(JOB_ID, JOB_NAME, TILE, DESCRIPTION, CREATED_TIME) VALUES(2, 'LAB05 CT105H', 'BAO CAO 2 LAB05 CT105H', 'DA HOAN THANH 40% CONG VIEC','04-11-2022 06:57 PM' );
INSERT INTO REPORT(JOB_ID, JOB_NAME, TILE, DESCRIPTION, CREATED_TIME) VALUES(3, 'NLCN', 'BAO CAO 1 NLCN', 'DA HOAN THANH 50% CONG VIEC','10-11-2022 01:00 PM' );
INSERT INTO REPORT(JOB_ID, JOB_NAME, TILE, DESCRIPTION, CREATED_TIME) VALUES(3, 'NLCN', 'BAO CAO 2 NLCN', 'DA HOAN THANH 60% CONG VIEC','12-11-2022 03:57 PM' );
INSERT INTO REPORT(JOB_ID, JOB_NAME, TILE, DESCRIPTION, CREATED_TIME) VALUES(4, 'BACKEND NLCN', 'BAO CAO 1 BACKEND NLCN', 'DA HOAN THANH 70% CONG VIEC','13-07-2022 03:00 AM' );
INSERT INTO REPORT(JOB_ID, JOB_NAME, TILE, DESCRIPTION, CREATED_TIME) VALUES(4, 'BACKEND NLCN', 'BAO CAO 2 BACKEND NLCN', 'DA HOAN THANH 80% CONG VIEC','14-07-2022 03:57 PM' );
INSERT INTO REPORT(JOB_ID, JOB_NAME, TILE, DESCRIPTION, CREATED_TIME) VALUES(5, 'LAO DONG SAN TRUONG', 'BAO CAO 1 LAO DONG SAN TRUONG', 'DA HOAN THANH 90% CONG VIEC','04-11-2022 07:30 AM' );
INSERT INTO REPORT(JOB_ID, JOB_NAME, TILE, DESCRIPTION, CREATED_TIME) VALUES(5, 'LAO DONG SAN TRUONG', 'BAO CAO 2 LAO DONG SAN TRUONG', 'DA HOAN THANH 100% CONG VIEC','04-01-2022 08:00 AM' );

DELIMITER //  
Create Trigger AUTO_DEL_JOB_WHEN_DEL_USER   
AFTER DELETE ON USER FOR EACH ROW  
BEGIN  
DELETE FROM JOB WHERE (ASSIGNOR_TYPE = 'USER' AND ASSIGNOR_ID = OLD.ID) OR (ASSIGNEE_TYPE = 'USER' AND ASSIGNEE_ID = OLD.ID);

END //  

DELIMITER // 
Create Trigger AUTO_DEL_REPORT_WHEN_JOB_CHANGE_ASSIGNEE   
AFTER UPDATE ON JOB FOR EACH ROW
BEGIN  
	IF ( ( NEW.ASSIGNEE_TYPE != OLD.ASSIGNEE_TYPE  ) || (NEW.ASSIGNEE_TYPE = OLD.ASSIGNEE_TYPE && NEW.ASSIGNEE_ID != OLD.ASSIGNEE_ID)) THEN
			DELETE FROM REPORT WHERE JOB_ID = NEW.ID;
	END IF;
END //  

DELIMITER // 
Create Trigger AUTO_UPDATE_USER_WORKING_HOUR   
AFTER UPDATE ON JOB FOR EACH ROW
BEGIN  
	IF ( OLD.ASSIGNEE_TYPE = "ADMIN" ) THEN
			UPDATE ADMIN SET TOTAL_WORKING_HOUR = (SELECT SUM(WORKED_HOUR) FROM JOB WHERE ASSIGNEE_TYPE = "ADMIN" AND ASSIGNEE_ID = OLD.ASSIGNEE_ID) WHERE ID = OLD.ASSIGNEE_ID; 
	END IF;
	IF ( OLD.ASSIGNEE_TYPE = "USER" ) THEN
			UPDATE USER SET TOTAL_WORKING_HOUR = (SELECT SUM(WORKED_HOUR) FROM JOB WHERE ASSIGNEE_TYPE = "USER" AND ASSIGNEE_ID = OLD.ASSIGNEE_ID) WHERE ID = OLD.ASSIGNEE_ID; 
	END IF;
	IF ( NEW.ASSIGNEE_TYPE = "ADMIN" ) THEN
			UPDATE ADMIN SET TOTAL_WORKING_HOUR = (SELECT SUM(WORKED_HOUR) FROM JOB WHERE ASSIGNEE_TYPE = "ADMIN" AND ASSIGNEE_ID = NEW.ASSIGNEE_ID) WHERE ID = NEW.ASSIGNEE_ID; 
	END IF;
	IF ( NEW.ASSIGNEE_TYPE = "USER" ) THEN
			UPDATE USER SET TOTAL_WORKING_HOUR = (SELECT SUM(WORKED_HOUR) FROM JOB WHERE ASSIGNEE_TYPE = "USER" AND ASSIGNEE_ID = NEW.ASSIGNEE_ID) WHERE ID = NEW.ASSIGNEE_ID; 
	END IF;
END //  