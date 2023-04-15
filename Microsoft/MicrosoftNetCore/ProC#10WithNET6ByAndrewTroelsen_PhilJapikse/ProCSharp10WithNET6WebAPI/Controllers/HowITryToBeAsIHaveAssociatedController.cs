using Microsoft.AspNetCore.Mvc;

using ProCSharp10WithNET6Library;

namespace ProCSharp10WithNET6WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HowITryToBeAsIHaveAssociatedController : ControllerBase
{
    private readonly ILogger<HowITryToBeAsIHaveAssociatedController> _logger;

    public HowITryToBeAsIHaveAssociatedController(ILogger<HowITryToBeAsIHaveAssociatedController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetHowITryToBeAsIHaveAssociated")]
    public String Get(String word)
    {
		return
		( 
			String.Format
			(
				"Forward: {0} Backward: {1}",
				HowITryToBeAsIHaveAssociated.Forward( word ),
				HowITryToBeAsIHaveAssociated.Backward( word )
			)	
		);
    }
}
