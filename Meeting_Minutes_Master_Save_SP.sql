
GO
/****** Object:  StoredProcedure [dbo].[Meeting_Minutes_Master_Save_SP]    Script Date: 5/16/2024 9:32:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create or alter PROCEDURE [dbo].[Meeting_Minutes_Master_Save_SP]
    @MeetingPlace NVARCHAR(MAX),
    @MeetingAgenda NVARCHAR(MAX),
    @MeetingDiscussion NVARCHAR(MAX),
    @AttendsFromClientSide NVARCHAR(MAX),
    @AttendsFromHostSide NVARCHAR(MAX),
    @MeetingDecision NVARCHAR(MAX),
    @CustomerId UNIQUEIDENTIFIER,
    @Date DATE,
    @Time TIME
AS
BEGIN
    INSERT INTO Meeting_Minutes_Master_Tbl ( Id,MeetingPlace, MeetingAgenda, MeetingDiscussion, AttendsFromClientSide, AttendsFromHostSide, MeetingDecision, CustomerId, Date, Time)
    VALUES (NEWID(),@MeetingPlace, @MeetingAgenda, @MeetingDiscussion, @AttendsFromClientSide, @AttendsFromHostSide, @MeetingDecision, @CustomerId, @Date, @Time);
END;