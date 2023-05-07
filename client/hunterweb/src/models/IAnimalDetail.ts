import {IHuntingSeason} from './IHuntingSeason';

export interface IAnimalDetail {
    name: string;
    imageUrl: string;
    description: string;
    tableId: string;
    huntingSeasons: IHuntingSeason[]
}