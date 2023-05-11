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

    static async createAnimal(animal:IAnimalDetail): Promise<AxiosResponse<void>> {
        return $api.post(`Animal`, animal) as Promise<AxiosResponse<void>>;
    }

    static async deleteAnimal(name:string): Promise<AxiosResponse<void>> {
        return $api.delete(`Animal`, {params:{name:name}}) as Promise<AxiosResponse<void>>;
    }

    static async updateAnimal(animal:IAnimalDetail): Promise<AxiosResponse<void>> {
        return $api.put(`Animal`, animal) as Promise<AxiosResponse<void>>;
    }
}