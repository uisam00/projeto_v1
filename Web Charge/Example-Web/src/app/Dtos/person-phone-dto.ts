import { PersonDto } from "./person-dto";
import { PhoneNumberTypeDto } from "./phone-number-type-dto";

export class PersonPhoneDto {
    businessEntityID: number;
    phoneNumberTypeID: number;
    phoneNumber: string;
    person:PersonDto
    phoneNumberType:PhoneNumberTypeDto
}
  