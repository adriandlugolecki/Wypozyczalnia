
const zasadyHaslo = [
    (wartosc) =>{
        if(wartosc) return true;
        else return "Pole jest wymagane"
    }
];
const zasadyLogin = [
    (wartosc) =>{
        if(wartosc) return true;
        else return "Pole jest wymagane"
    }
];
export{
    zasadyHaslo,
    zasadyLogin,
};