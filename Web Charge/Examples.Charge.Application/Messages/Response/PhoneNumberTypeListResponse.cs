using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Messages.Response
{
    public class PhoneNumberTypeListResponse : BaseResponse
    {
        public List<PhoneNumberTypeDto> PhoneNumberTypeObjects { get; set; }
    }
}
