export interface User {
    id: number;
    name: string;
    surname: string;
    email: string;
    street: string;
    postalCode: string;
    city: string;
    countryId: number;
    country: Country;
    phone: string;
}
