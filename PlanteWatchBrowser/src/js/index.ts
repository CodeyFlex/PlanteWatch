import axios, {
    AxiosResponse,
    AxiosError
} from "../../node_modules/axios/index"

interface IDataLinks {
    "self": string,
    "genus": string,
    "plant": string
}

interface ITrefleData {
    "id": number,
    "common_name": string,
    "slug": string,
    "scientific_name": string,
    "year": number,
    "bibliography": string,
    "author": string,
    "status": string,
    "rank": string,
    "family_common_name": string,
    "family": string,
    "genus_id": number,
    "image_url": string,
    "synonyms": string[];
    "genus": string,
    "links": IDataLinks
}

interface ILinks {
    "self": string,
    "first": string,
    "last": string
    "next": string
    "prev": string
}

interface IMeta {
    "total": number
}

interface ITrefleModel {
    "data": ITrefleData[];
    "links": ILinks;
    "meta": IMeta;
}

interface IPlant {
    "id": number,
    "name": string,
    "humidity": number,
    "nutrition": number,
}

interface IGreenhouse {
    "id": number,
    "name": string,
    "humidity": number,
    "temperature": number,
    "lightLevel": number,
}

let trefleUrl = 'http://localhost:51283/api/PlanteWatch/Trefle'
let planteWatchPlantURL = 'http://localhost:51283/api/PlanteWatch/Plant'
let planteWatchgreenhouseURL = 'http://localhost:51283/api/PlanteWatch/Greenhouse'

new Vue({
    // TypeScript compiler complains about Vue because the CDN link to Vue is in the html file.
    // Before the application runs this TypeScript file will be compiled into bundle.js
    // which is included at the bottom of the html file.

    el: "#wrapper",
    data: {
        //Local API
        plants: { Id: Number, Name: String, Humidity: Number, Nutrition: Number },
        greenhouses: { Id: Number, Name: String, Humidity: Number, Temperature: Number, LightLevel: Number },

        //Trefle (not being used atm)
        trefleModel: {
            trefleData: [{
                Id: Number, Common_Name: String, Slug: String, Scientific_Name: String, Year: Number,
                bibliography: String, author: String, status: String, rank: String, family_common_name: String,
                family: String, genus_id: String, image_url: String, synonyms: Array, genus: String, trefleDataLinks: { Self: String, Genus: String, Plant: String },
            }],
            trefleLinks: { Self: String, First: String, Last: String, next: String, prev: String },
            trefleMeta: { Total: Number }
        },

        //Search
        searchPlant: null,
        searchGreenhouse: null,
        searchTrefle: null,
        searchInput: "",

        //Totals
        greenhousesTotal: 0,
        plantsTotal: 0,

        //Bools
        gettingPlants: false,
        gettingGreenhouses: false,
        searchingPlants: false,
        searchingGreenhouses: false,
        searchingTrefleName: false,
    },

    methods: {
        //ES2018
        //From Local API: Plants
        async getAllPlantsAsync(initBool: boolean) {
            console.log("Getting Plants");

            if (initBool == true) {
                //Boolean set
                this.setBooleans("getPlants")
            }

            try { return axios.get<IPlant[]>(planteWatchPlantURL) }
            catch (any) {
                this.message = any.message;
                alert(any.message)
            }
        },

        //From Local API: Plants
        async getAllPlants() {
            let response = await this.getAllPlantsAsync(true);
            this.plants = response.data;

            //Total display
            this.plantsTotal = this.plants.length;
        },

        //From Local API: Greenhouses
        async getAllGreenhousesAsync(initBool: boolean) {
            console.log("Getting Greenhouses");

            if (initBool == true) {
                //Boolean set
                this.setBooleans("getGreenhouses")
            }

            try { return axios.get<IGreenhouse[]>(planteWatchgreenhouseURL) }
            catch (any) {
                this.message = any.message;
                alert(any.message)
            }
        },

        //From Local API: Greenhouses
        async getAllGreenhouses() {
            let response = await this.getAllGreenhousesAsync(true);
            this.greenhouses = response.data;

            //Total display
            this.greenhousesTotal = this.greenhouses.length;
        },

        //Initates the "Total" displays
        async init() {
            console.log("Initiating totals")

            let response = await this.getAllPlantsAsync(false);
            this.plants = response.data;

            let response2 = await this.getAllGreenhousesAsync(false);
            this.greenhouses = response2.data;

            //Total display
            this.plantsTotal = this.plants.length;
            this.greenhousesTotal = this.greenhouses.length;
        },

        //Clear
        clearList() {
            this.greenhouses = [];
            this.searchPlant = null;
            this.searchGreenhouse = null;
        },

        //Search Trefle API: Plants
        searchTreflePlantByName(name: String) {
            console.log("Getting Trefle Plant by Name");

            //Boolean set
            this.setBooleans("searchTrefleName")

            let url: string = trefleUrl + "/Name/" + name
            axios.get<ITrefleModel>(url)
                .then((response: AxiosResponse<ITrefleModel>) => {
                    this.searchTrefle = response.data
                })
                .catch((error: AxiosError) => {
                    this.message = error.message
                    alert(error.message)
                })
        },

        //Search Local API: Plants
        getPlantByName(name: String) {
            console.log("Getting Plant by Name");

            //Boolean set
            this.setBooleans("searchPlants")

            let url: string = planteWatchPlantURL + "/Name/" + name
            axios.get<IPlant>(url)
                .then((response: AxiosResponse<IPlant>) => {
                    this.searchPlant = response.data
                })
                .catch((error: AxiosError) => {
                    this.message = error.message
                    alert(error.message)
                })
        },

        //Search Local API: Greenhouses
        getGreenhouseByName(name: String) {
            console.log("Getting Greenhouse by Name");

            //Boolean set
            this.setBooleans("searchGreenhouses")

            let url: string = planteWatchgreenhouseURL + "/Name/" + name
            axios.get<IPlant>(url)
                .then((response: AxiosResponse<IPlant>) => {
                    this.searchGreenhouse = response.data
                })
                .catch((error: AxiosError) => {
                    this.message = error.message
                    alert(error.message)
                })
        },

        //Boolean setter
        setBooleans(booleanChoice: String) {
            if (booleanChoice != "getPlants") {
                this.gettingPlants = false;
            }
            else {
                this.gettingPlants = true;
            }

            if (booleanChoice != "getGreenhouses") {
                this.gettingGreenhouses = false;
            }
            else {
                this.gettingGreenhouses = true;
            }

            if (booleanChoice != "searchPlants") {
                this.searchingPlants = false;
            }
            else {
                this.searchingPlants = true;
            }

            if (booleanChoice != "searchGreenhouses") {
                this.searchingGreenhouses = false;
            }
            else {
                this.searchingGreenhouses = true;
            }

            if (booleanChoice != "searchTrefleName") {
                this.searchingTrefleName = false;
            }
            else {
                this.searchingTrefleName = true;
            }
        },
    },

    //Run this when page is rendered
    mounted: function () {
        this.$nextTick(async function () {

            //Get Totals from Local API 
            let plantsResponse = await this.getAllPlantsAsync(false);
            this.plants = plantsResponse.data;

            let greenhouseResponse = await this.getAllGreenhousesAsync(false);
            this.greenhouses = greenhouseResponse.data;

            this.plantsTotal = this.plants.length;
            this.greenhousesTotal = this.greenhouses.length;
        })
    }
})