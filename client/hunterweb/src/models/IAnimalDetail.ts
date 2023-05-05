import {IHuntingSeason} from './IHuntingSeason';

export interface IAnimalDetail {
    name: string;
    image_url: string;
    description: string;
    table_id: string;
    hunting_seasons: IHuntingSeason[]
}