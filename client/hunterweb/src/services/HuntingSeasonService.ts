import {AxiosResponse} from 'axios';
import $api from '../http';
import {IAnimalDetail} from '../models/IAnimalDetail';
import {IAnimalDetailResponse} from '../models/response/IAnimalDetailResponse';
import {IHuntingSeason} from '../models/IHuntingSeason';

export default class HuntingSeasonService {
    static async deleteSeason(id:number): Promise<AxiosResponse<void>> {
        return $api.delete(`HuntingSeason`, {params:{id:id}}) as Promise<AxiosResponse<void>>;
    }

    static async create(huntingSeason:IHuntingSeason): Promise<AxiosResponse<void>> {
        return $api.post(`HuntingSeason`, huntingSeason) as Promise<AxiosResponse<void>>;
    }

    static async update(huntingSeason:IHuntingSeason): Promise<AxiosResponse<void>> {
        return $api.put(`HuntingSeason`, huntingSeason) as Promise<AxiosResponse<void>>;
    }
}