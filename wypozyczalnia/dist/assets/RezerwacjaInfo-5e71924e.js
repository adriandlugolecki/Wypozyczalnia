import{r as u,o as B,s as p,B as z,b as N,c as d,d as W,h as a,t as l,u as h,j as o,k as S,l as C,g as f,m as x,w as O,p as i,x as P,y as R}from"./index-9a356706.js";import{_ as T}from"./_plugin-vue_export-helper-c27b6911.js";const t=c=>(P("data-v-ac9f277a"),c=c(),R(),c),$={class:"tlo"},D={class:"okno"},V={class:"tytul"},K={class:"info"},Z=t(()=>a("h3",null,"klient:",-1)),M=t(()=>a("br",null,null,-1)),E=t(()=>a("h3",null,"Pesel:",-1)),G=t(()=>a("h3",null,"Telefon:",-1)),U=["src"],q=t(()=>a("h3",null,"samochod:",-1)),A=t(()=>a("br",null,null,-1)),F=t(()=>a("br",null,null,-1)),H=t(()=>a("h3",null,"Dane Kierowcy",-1)),J=t(()=>a("br",null,null,-1)),L={__name:"RezerwacjaInfo",setup(c){const e=u(),v=u(!1),r=u(!1),k=u(),m=u(""),y=u();B(async()=>{try{k.value=p.currentRoute.value.params.id;var n=await z.get(`/Pracownik/WypozyczenieInfo/${k.value}`);e.value=n.data,m.value="https://localhost:7122/Photos/"+e.value.samochod.id+".png"}catch{}});const j=async n=>{e.value.czyWydano==!1?v.value=!0:v.value=!1,await z.patch(`/Pracownik/ZmianaStatusuWypozyczenia/${n}`,{czyWydano:v.value,czyOddano:e.czyOddano}),i.tekst="wydano",i.show=!0,p.push("/pracownik")},I=async n=>{e.value.czyOddano==!1?r.value=!0:r.value=!1,await z.patch(`/Pracownik/ZmianaStatusuWypozyczenia/${n}`,{czyWydano:!0,czyOddano:r.value,Notatka:y.value}),i.tekst="Odebrano",i.show=!0,p.push("/pracownik")};let w=n=>n.split("T")[0],g=()=>e.value.ubezpieczenieId==1?2e3:1;return(n,s)=>{const b=N("v-btn");return d(),W("div",$,[a("div",D,[a("div",V," Wypożyczenie NR: "+l(e.value?e.value.id:"")+" | "+l(e.value?h(w)(e.value.data):"")+" - "+l(e.value?h(w)(e.value.dataZakonczenia):""),1),a("div",K,[a("div",null,[Z,o(" "+l(e.value?e.value.klient.imie:"")+" "+l(e.value?e.value.klient.nazwisko:""),1),M,E,o(" "+l(e.value?e.value.klient.pesel:"")+" ",1),G,o(" "+l(e.value?e.value.klient.phoneNumber:""),1)]),a("div",null,[a("img",{width:"150",src:m.value},null,8,U)]),a("div",null,[q,o(" Id: "+l(e.value?e.value.samochod.id:""),1),A,o(" "+l(e.value?e.value.samochod.marka:"")+" "+l(e.value?e.value.samochod.model:""),1),F,o(" ["+l(e.value?e.value.samochod.rejestracja:"")+"] ",1)]),a("div",null,[H,a("div",null,[o(l(e.value?e.value.imie:""),1),J,o(" "+l(e.value?e.value.nazwisko:""),1)]),a("div",null,"telefon: "+l(e.value?e.value.telefon:""),1)])]),a("div",null,"Koszt wypożyczenia : "+l(e.value?e.value.kwota:"")+" zł",1),a("div",null,"kaucja : "+l(e.value?h(g)():"")+" zł",1),e.value&&e.value.czyWydano==!0&&e.value.czyOddano==!1?S((d(),W("textarea",{key:0,style:{"background-color":"white","border-radius":"30px",padding:"10px"},cols:"50",rows:"5",type:"text",placeholder:"Notatka","onUpdate:modelValue":s[0]||(s[0]=_=>y.value=_)},null,512)),[[C,y.value]]):f("",!0),a("div",null,[e.value&&e.value.czyWydano==!1&&e.value.czyOddano==!1?(d(),x(b,{key:0,onClick:s[1]||(s[1]=_=>j(e.value.id)),color:"#ebcc39"},{default:O(()=>[o("Wydaj ")]),_:1})):f("",!0),e.value&&e.value.czyWydano==!0&&e.value.czyOddano==!1?(d(),x(b,{key:1,onClick:s[2]||(s[2]=_=>I(e.value.id)),color:"#ebcc39"},{default:O(()=>[o("Odbierz ")]),_:1})):f("",!0)])])])}}},Y=T(L,[["__scopeId","data-v-ac9f277a"]]);export{Y as default};
