import {AxiosResponse} from 'axios';
import $api from '../http';
import {IAnimalDetail} from '../models/IAnimalDetail';
import {IAnimalDetailResponse} from '../models/response/IAnimalDetailResponse';

export default class AnimalService {
    static async getByName(name: string): Promise<AxiosResponse<IAnimalDetail>> {
        return $api.get(`Animal/get/${name}`) as Promise<AxiosResponse<IAnimalDetail>>;
    }

    static async getAll(): Promise<AxiosResponse<IAnimalDetail[]>> {
        return $api.get(`Animal/get`) as Promise<AxiosResponse<IAnimalDetail[]>>;
    }
}