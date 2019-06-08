import { Photo } from './Photo';

export interface User {
    id: number;
    name: string;
    ProfileCreatedFor: string;
    age: number;
    photoUrl: string;
    photos?: Photo[];

    profileCreatedFor: string;
    gender: string;
    motherTongue: string;
    religion: string;
    cast: string;
    subCast?: string;
    maritalStatus: string;
    pinCode?: string;
    address: string;
    dateOfBirth: Date;
    created: Date;
    lastActive: Date;
    introduction?: string;
    lookingFor?: string;
    interests?: string;
    callingCode?: string;
    mobileNumber: string;
    city: string;
    state: string;
    country: string;

    //Physical
    height: number;
    weight: number;
    bodyType: string;
    complexion: string;
    physicalStatus: string;

    //Qualification & Occupation
    highestQualification: string;
    employmentType: string;
    occupation: string;
    currency: string;
    monthlyIncome: number;

    //Astrological
    star: string;
    raasi: string;
    chovvaDosam: string;
    timeOfBirth: Date;

    //Habits
    /// <summary>
    /// Vegetarian,NonVegetarian,Eggetarian
    /// </summary>
    foodHabits: string;
    smoking: string;
    drinking: string;

    //Family Profile
    /// <summary>
    /// Upper,Middle,Rich,Affluent
    /// </summary>
    familyStatus: string;
    /// <summary>
    /// Joint Family,Nuclear Family,Others
    /// </summary>
    familyType: string;

    /// <summary>
    /// Orthodox,Traditional,Moderate,Liberal
    /// </summary>
    familyValues: string;
    parentsMobileNumber?: string;
    parentsMonthlyIncome?: string;
    username: string;
    email: string;
    password: string;
}
