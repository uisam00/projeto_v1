import { PersonPhoneDto } from "./person-phone-dto";
import { PhoneNumberTypeDto } from "./phone-number-type-dto";

export class PersonPhoneAuxDto {
    idPersonPhone: number;
    personPhone: PersonPhoneDto;

    constructor(idPersonPhone:number, personPhone:PersonPhoneDto){
        this.idPersonPhone = idPersonPhone,
        this.personPhone = personPhone
    }

}
  