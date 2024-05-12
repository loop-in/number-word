using Microsoft.AspNetCore.Mvc;
using NumberToWord.Api.Applications;
using NumberToWord.Api.Applications.Features;

namespace NumberToWord.Api.Controllers;

[ApiController]
[Route("converters")]
public class ConverterController(
    IConverterService converterService) : ControllerBase
{
    [HttpGet("moneys")]
    public BaseResponse<string> Get(string value)
    {
        return converterService.MoneyToWord(value);
    }
}
