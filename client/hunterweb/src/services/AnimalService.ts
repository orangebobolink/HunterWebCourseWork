import {AxiosResponse} from 'axios';
import $api from '../http';
import {IAnimalDetail} from '../models/IAnimalDetail';
import {IAnimalDetailResponse} from '../models/response/IAnimalDetailResponse';

export default class AnimalService {
    static async getByName(name: string): Promise<AxiosResponse<IAnimalDetail>> {
        return $api.get(`Animal/name`,{params: {name:name}}) as Promise<AxiosResponse<IAnimalDetail>>;
    }

    static async getAll(): Promise<AxiosResponse<IAnimalDetail[]>> {
        return $api.get(`Animal`) as Promise<AxiosResponse<IAnimalDetail[]>>;
    }

    static async createAnimal(name:string, description:string, imageUrl:string): Promise<AxiosResponse<void>> {
        return $api.post(`Animal`, {name, description, imageUrl}) as Promise<AxiosResponse<void>>;
    }
}