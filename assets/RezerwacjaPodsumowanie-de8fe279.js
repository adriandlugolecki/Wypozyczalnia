import{_ as L,D as q,E as F,c as e,r as u,o as Y,I as C,z as G,q as H,d as z,e as g,f as w,g as k,k as v,h as c,t,u as a,m as f,w as J,i as M,s as P,A as Q,x as R}from"./index-dcca130b.js";const X="/Wypozyczalnia/assets/fotor-ai-20240107215829-246fd1d0.jpg";const n=h=>(q("data-v-cf3ed9e5"),h=h(),F(),h),ee={class:"tlo"},oe=n(()=>e("div",{class:"PodsumowanieTytul"},[e("h1",null,"Podsumowanie")],-1)),ae={class:"okno"},te={class:"podsumowanie"},le={key:0},se=n(()=>e("div",null,"Odbiór",-1)),ne=n(()=>e("div",null,"Słoneczna 54, Olsztyn",-1)),ue=n(()=>e("div",null,"Zwrot",-1)),de=n(()=>e("div",null,"Słoneczna 54, Olsztyn",-1)),ie={key:0},ce={class:"samochodZdjecie"},re=["src"],ve={class:"samochodOpis"},me=n(()=>e("h2",null,"Ubezpieczenie",-1)),_e={class:"podsumowanieKwota"},pe=n(()=>e("h2",null,"Kosztorys",-1)),ze=n(()=>e("span",{class:"gold2"},"Samochód ",-1)),we=n(()=>e("span",{class:"gold2"},"Ubezpieczenie",-1)),ke=n(()=>e("span",{class:"gold2"},"Wiek Kierowcy",-1)),he=n(()=>e("span",{class:"gold2"},"Całkowita kwota",-1)),ye={key:0},ge={key:1},fe=n(()=>e("img",{src:X,height:"200",style:{"border-radius":"30px","margin-top":"50px"}},null,-1)),be={class:"podsumowanieKierowca"},Ve=n(()=>e("h2",null,"Dane kierowcy",-1)),Se={__name:"RezerwacjaPodsumowanie",setup(h){const W=localStorage.getItem("auto"),b=localStorage.getItem("ubezpieczenie"),p=localStorage.getItem("wiek"),V=new Date(localStorage.getItem("data")),S=new Date(localStorage.getItem("dataZakonczenia")),l=u(),d=u(),m=Math.ceil(Math.abs(S-V)/(1e3*3600*24)),I=u(!0),x=u(!0),Z=u(""),j=u(),U=u(),D=u(),K=u(),N=u(),$=u(),B=u();Y(async()=>{try{var r=await C.get(`/Samochod/${W}`),o=await C.get(`/Ubezpieczenie/${b}`);l.value=r.data,d.value=o.data,Z.value=G+l.value.id+".png"}catch(_){console.error("Błąd",_)}});const A=async r=>{var _;await r;const o=await((_=B.value)==null?void 0:_.validate());if(o&&o.valid)try{const i=m*(d.value.kwota+l.value.cena+y(p));console.log(i),await C.post("/klient/wypozyczeniesamochodu",{samochodId:l.value.id,klientId:"id",data:V,dataZakonczenia:S,ileDni:m,ubezpieczenieId:d.value.id,wiek:p,kwota:i,imie:j.value,nazwisko:U.value,telefon:D.value,adres:K.value,miejscowosc:N.value,kodPocztowy:$.value}),H.push("/"),z.tekst="Samochód został zarezerwowany",z.show=!0}catch(i){z.tekst=i.response.data,z.error=!0,z.show=!0}},O=r=>`${r.getDate()}.${r.getMonth()+1}.${r.getFullYear()}`,y=r=>r==1?0:20;return(r,o)=>{const _=g("v-btn"),i=g("v-text-field"),T=g("RouterLink"),E=g("v-form");return w(),k("div",ee,[oe,e("div",ae,[e("div",te,[e("div",null,[e("h2",null,[v(" odbiór i zwrot "),c(_,{elevation:"0",icon:"mdi-book-open",onClick:o[0]||(o[0]=s=>I.value=!I.value)})])]),I.value?(w(),k("div",le,[e("div",null,[se,ne,v(" "+t(O(a(V)))+" od godziny 12:00 ",1)]),e("div",null,[ue,de,v(" "+t(O(a(S)))+" do godziny 10:00 ",1)])])):f("",!0),e("div",null,[e("h2",null,[v(" Samochod"),c(_,{icon:"mdi-book-open",elevation:"0",onClick:o[1]||(o[1]=s=>x.value=!x.value)})]),x.value?(w(),k("div",ie,[e("div",ce,[e("img",{width:"150",src:Z.value},null,8,re)]),e("div",ve,t(l.value?l.value.marka:"")+" "+t(l.value?l.value.model:""),1)])):f("",!0)]),e("div",null,[me,v(" "+t(d.value?d.value.nazwa:""),1)])]),e("div",_e,[pe,e("div",null,[ze,v(" "+t(a(m))+" x "+t(l.value?l.value.cena:"")+" = "+t(a(m)*(l.value?l.value.cena:""))+" zł ",1)]),e("div",null,[we,v(" "+t(a(m))+" x "+t(d.value?d.value.kwota:"")+" = "+t(a(m)*(d.value?d.value.kwota:""))+" zł ",1)]),e("div",null,[ke,v(" "+t(a(m))+" x "+t(y(a(p)))+" = "+t(a(m)*y(a(p)))+" zł ",1)]),e("div",null,[he,v(" "+t(a(m)*((d.value?d.value.kwota:"")+(l.value?l.value.cena:"")+y(a(p))))+" zł ",1)]),a(b)==1?(w(),k("div",ye,"Kaucja: 2000 zł")):f("",!0),a(b)==2?(w(),k("div",ge,"Kaucja: 1 zł")):f("",!0),fe]),e("div",be,[c(E,{ref_key:"formularz",ref:B,onSubmit:J(A,["prevent"])},{default:M(()=>[Ve,c(i,{label:"Imie",modelValue:j.value,"onUpdate:modelValue":o[2]||(o[2]=s=>j.value=s),rules:a(P)},null,8,["modelValue","rules"]),c(i,{label:"Nazwisko",modelValue:U.value,"onUpdate:modelValue":o[3]||(o[3]=s=>U.value=s),rules:a(P)},null,8,["modelValue","rules"]),c(i,{label:"Numer telefonu",modelValue:D.value,"onUpdate:modelValue":o[4]||(o[4]=s=>D.value=s),rules:a(Q)},null,8,["modelValue","rules"]),c(i,{label:"Adres",modelValue:K.value,"onUpdate:modelValue":o[5]||(o[5]=s=>K.value=s),rules:a(R)},null,8,["modelValue","rules"]),c(i,{label:"Miejscowość",modelValue:N.value,"onUpdate:modelValue":o[6]||(o[6]=s=>N.value=s),rules:a(P)},null,8,["modelValue","rules"]),c(i,{label:"Kod pocztowy",modelValue:$.value,"onUpdate:modelValue":o[7]||(o[7]=s=>$.value=s),rules:a(R)},null,8,["modelValue","rules"]),c(T,{to:"/podsumowanie",custom:""},{default:M(({navigate:s})=>[c(_,{class:"mt-5 mb-5",type:"submit",color:"yellow"},{default:M(()=>[v(" zarezerwuj ")]),_:1})]),_:1})]),_:1},8,["onSubmit"])])])])}}},xe=L(Se,[["__scopeId","data-v-cf3ed9e5"]]);export{xe as default};
