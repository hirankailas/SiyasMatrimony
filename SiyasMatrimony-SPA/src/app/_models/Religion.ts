import { Caste } from './Caste';

export interface Religion {
    id: number;
    name: string;
    castes: Caste[];
}
