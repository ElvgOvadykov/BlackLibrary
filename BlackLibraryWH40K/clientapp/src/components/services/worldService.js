export default class WorldService{
    _baseUrl = 'https://localhost:44302/api/Worlds/';
    
    async getWorlds() {
        const url = this._baseUrl;
        console.log(url);
        const response = await fetch(url);
        return await response.json();
    }
    
    async getWorld(id) {
        const url = this._baseUrl + id;
        console.log(url);
        const response = await fetch(url);
        return await response.json();
    }
}