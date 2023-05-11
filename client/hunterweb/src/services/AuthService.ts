import $api from '../http';
import {AxiosResponse} from 'axios';
import {IAuthRepsponse} from '../models/response/IAuthRepsponse';
import {IUserDetail} from '../models/IUserDetail';
import {IRegisterUser} from '../models/IRegisterUser';

export default class AuthService {
    static async login(email: string, password: string): Promise<AxiosResponse<IAuthRepsponse>> {
        return $api.post<IAuthRepsponse>('Auth/login', {email, password});
    }

    static async registration(user:IRegisterUser): Promise<AxiosResponse<IAuthRepsponse>> {
        return $api.post<IAuthRepsponse>('Auth/registration', user);
    }

    static async logout(): Promise<void> {
        return $api.post('Auth/logout');
    }
}

