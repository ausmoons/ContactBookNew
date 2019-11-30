import { Phones } from "./phones";
import { Addresses } from "./addresses";
import { Emails } from "./emails";

export interface Contact {
    id: number;
    name1: string;
    name2?: string;
    surname1: string;
    surname2?: string;
    birthday?: Date;
    company?: string;
    notes?: Text;
    photo?: File;
    phones: Phones[];
    addresses: Addresses[];
    emails: Emails[];
}

