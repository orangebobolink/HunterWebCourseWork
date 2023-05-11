import {IHuntingSeason} from './IHuntingSeason';

export interface IAnimalDetail {
    id?:number
    name: string;
    englishName: string;
    imageUrl: string;
    description: string;
    tableId: string;
    huntingSeasons: IHuntingSeason[]
}