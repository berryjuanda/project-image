USE [db_Mahasiswa]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 13/07/2022 14:54:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[ImageID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](250) NULL,
	[ImagePath] [varchar](max) NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([ImageID], [Title], [ImagePath]) VALUES (2, N'Kapak', N'~/Content/img/autumn-sunrise-eiffel-tower-paris-france-wallpaper-preview221210884.jpg')
INSERT [dbo].[Image] ([ImageID], [Title], [ImagePath]) VALUES (3, N'Ronald', N'~/Content/img/Gelas Karakter225142709.jpg')
INSERT [dbo].[Image] ([ImageID], [Title], [ImagePath]) VALUES (4, N'Api', N'~/Content/img/KOTAK-SUARA225430621.jpg')
INSERT [dbo].[Image] ([ImageID], [Title], [ImagePath]) VALUES (5, N'Gelas', N'~/Content/img/Gelas Karakter220716519.jpg')
INSERT [dbo].[Image] ([ImageID], [Title], [ImagePath]) VALUES (6, N'Paris', N'~/Content/img/autumn-sunrise-eiffel-tower-paris-france-wallpaper-preview221210884.jpg')
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
/****** Object:  StoredProcedure [dbo].[stp_DetailImage]    Script Date: 13/07/2022 14:54:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stp_DetailImage]
	-- Add the parameters for the stored procedure here
	@id int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Image WHERE ImageID=@id
END

--execute stp_DetailImage 2;
GO
/****** Object:  StoredProcedure [dbo].[stp_DisplayImage]    Script Date: 13/07/2022 14:54:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stp_DisplayImage] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Image
END
--execute stp_DisplayImage;
GO
/****** Object:  StoredProcedure [dbo].[stp_UpdateImage]    Script Date: 13/07/2022 14:54:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stp_UpdateImage] 
	-- Add the parameters for the stored procedure here
	@id int,
	@title varchar(250),
	@path varchar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [db_Mahasiswa].[dbo].[Image] set Title=@title, ImagePath=@path 
	WHERE ImageID=@id
END

--execute stp_UpdateImage @id=2,@title='Kapak',@path='~/Content/img/autumn-sunrise-eiffel-tower-paris-france-wallpaper-preview221210884.jpg';
GO
/****** Object:  StoredProcedure [dbo].[stp_UploadImage]    Script Date: 13/07/2022 14:54:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stp_UploadImage] 
	-- Add the parameters for the stored procedure here
	@title varchar(250),
	@imagePath varchar (MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [db_Mahasiswa].[dbo].[Image](Title,ImagePath) VALUES (@title,@imagePath) 
END



GO
