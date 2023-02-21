SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

use remindme
go

if object_id('dbo.usp_getProfessionCodes') is not null
begin
    drop procedure dbo.usp_getProfessionCodes
end
go

CREATE procedure dbo.usp_getProfessionCodes
as
select distinct profession_code, [description]
from   dbo.support_profession (nolock)
order  by 2
GO

grant execute on dbo.usp_getProfessionCodes to webUser
go

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--exec dbo.usp_getProfessionCodes