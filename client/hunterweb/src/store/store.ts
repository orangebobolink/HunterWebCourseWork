import {IUser} from '../models/IUser';
import {makeAutoObservable} from 'mobx';
import AuthService from '../services/AuthService';
import axios from 'axios';
import {IAuthRepsponse} from '../models/response/IAuthRepsponse';
import $api, {API_URL} from '../http';


export default class Store {
    user = {} as IUser;
    isAuth = false;
    isLoading = false;
    isAdmin = false;

    constructor() {
        makeAutoObservable(this);
    }

    setAuth(bool: boolean) {
        this.isAuth = bool;
    }

    setUser(user: IUser) {
        this.user = user;
    }

    setLoading(bool: boolean) {
        this.isLoading = bool;
    }

    setAdmin(bool: boolean) {
        this.isAdmin = bool;
    }

    async login(email: string, password: string) {
        try {
            const response = await AuthService.login(email, password);
            console.log(response);

            localStorage.setItem('token', response.data.accessToken);
            this.setAuth(true);

            const user : IUser = {
                email: response.data.email,
                roles: response.data.roles
            }

            this.setUser(user);

            if (this.user.roles.includes('admin')) {
                this.setAdmin(true);
            }
        } catch (e: any) {
            console.log(e.response?.data?.message);
        }
    }

    async registration(email: string, password: string) {
        try {
            const response = await AuthService.registration(email, password);
            console.log(response);
            localStorage.setItem('token', response.data.accessToken);
            this.setAuth(true);

            const user : IUser = {
                email: response.data.email,
                roles: response.data.roles
            }

            this.setUser(user);

            if (this.user.roles.includes('admin')) {
                this.setAdmin(true);
            }
        } catch (e: any) {
            console.log(e.response?.data?.message);
        }
    }

    async logout() {
        try {
            const response = await AuthService.logout();
            localStorage.removeItem('token');
            this.setAuth(false);
            this.setUser({} as IUser);
            this.setAdmin(false);
        } catch (e: any) {
            console.log(e.response?.data?.message);
        }
    }

    async checkAuth() {
        this.setLoading(true);
        try {
            axios.defaults.withCredentials = true;
            const response = await axios.post("http://localhost:5114/api/Auth/refresh")
            console.log(response);
            localStorage.setItem('token', response.data.accessToken);
            this.setAuth(true);

            const user : IUser = {
                email: response.data.email,
                roles: response.data.roles
            }

            this.setUser(user);

            if (this.user.roles.includes('admin')) {
                this.setAdmin(true);
            }
        } catch (e: any) {
            console.log(e.response?.data?.message);
        } finally {
            this.setLoading(false);
        }
    }
}
