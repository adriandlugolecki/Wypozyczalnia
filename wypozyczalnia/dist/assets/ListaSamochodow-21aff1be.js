import{_ as T,D as q,E,c as a,r as l,o as O,I as y,d as c,e as v,f as d,g as M,h as p,w as P,i as k,j as t,v as n,l as g,k as $,m as C,F as W,n as G,p as U,t as w}from"./index-dcca130b.js";const s=m=>(q("data-v-5120803e"),m=m(),E(),m),H={class:"tlo"},J={class:"okno"},K=s(()=>a("h1",{class:"tytul"},"Samochody",-1)),Q={key:0,class:"formularz"},X=s(()=>a("option",{value:"null",selected:"",hidden:""},"Wybierz",-1)),Y=s(()=>a("option",{value:"0"},"Benzyna",-1)),ee=s(()=>a("option",{value:"1"},"Diesel",-1)),oe=[X,Y,ee],ae=s(()=>a("option",{value:"null",selected:"",hidden:""},"Wybierz",-1)),le=s(()=>a("option",{value:"0"},"Manual",-1)),te=s(()=>a("option",{value:"1"},"Automat",-1)),ne=[ae,le,te],se={__name:"ListaSamochodow",setup(m){const B=l([]),b=l([]),j=l(!1),z=l(),f=l(),S=l(),V=l(),D=l(),h=l(),u=l(0),r=l(0),x=l();O(async()=>{try{var i=await y.get("/Admin/ListaSamochodow");B.value=i.data}catch{}});const A=async()=>{try{u.value=parseInt(u.value),r.value=parseInt(r.value);var i=await y.post("/Admin/DodajSamochod",{marka:z.value,model:f.value,Rejestracja:S.value,rocznik:V.value,liczbaMiejsc:h.value,liczbaDrzwi:D.value,rodzajSkrzyni:u.value,rodzajPaliwa:r.value,cena:x.value});let e=new FormData;e.append("zdjecie",b.value[0]),await y.post(`/Admin/DodajZdjecie/${i.data.id}`,e),c.tekst="Dodano samochód",c.show=!0,location.reload()}catch{c.tekst="Błąd",c.error=!0,c.show=!0,location.reload()}},I=async i=>{await y.patch(`/Admin/ZablokujOdblokujSamochod/${i}`),location.reload()};return(i,e)=>{const _=v("v-btn"),L=v("v-file-input"),N=v("v-card"),R=v("v-form"),Z=v("v-list-item");return d(),M("div",H,[a("div",J,[p(_,{elevation:"0",class:"dodanie",icon:"mdi-plus-circle",onClick:e[0]||(e[0]=o=>j.value=!j.value)}),K,j.value?(d(),M("div",Q,[p(R,{onSubmit:e[12]||(e[12]=P(()=>{},["prevent"]))},{default:k(()=>[p(N,{width:"80%",height:"50px",elevation:"0",class:"center mr-10 ml-10 mb-10"},{default:k(()=>[p(L,{modelValue:b.value,"onUpdate:modelValue":e[1]||(e[1]=o=>b.value=o),label:"dodaj zdjęcie"},null,8,["modelValue"])]),_:1}),a("div",null,[t(a("input",{type:"text","onUpdate:modelValue":e[2]||(e[2]=o=>z.value=o),placeholder:"Marka",class:"wybor"},null,512),[[n,z.value]]),t(a("input",{type:"text","onUpdate:modelValue":e[3]||(e[3]=o=>f.value=o),placeholder:"Model",class:"wybor"},null,512),[[n,f.value]]),t(a("input",{type:"text","onUpdate:modelValue":e[4]||(e[4]=o=>S.value=o),placeholder:"Rejestracja",class:"wybor"},null,512),[[n,S.value]]),t(a("input",{type:"numer","onUpdate:modelValue":e[5]||(e[5]=o=>V.value=o),placeholder:"Rocznik",class:"wybor"},null,512),[[n,V.value]]),t(a("input",{type:"numer","onUpdate:modelValue":e[6]||(e[6]=o=>D.value=o),placeholder:"liczbaDrzwi",class:"wybor"},null,512),[[n,D.value]]),t(a("input",{type:"numer","onUpdate:modelValue":e[7]||(e[7]=o=>h.value=o),placeholder:"liczbaMiejsc",class:"wybor"},null,512),[[n,h.value]]),t(a("select",{"onUpdate:modelValue":e[8]||(e[8]=o=>r.value=o),required:"",class:"wybor"},oe,512),[[g,r.value]]),t(a("select",{"onUpdate:modelValue":e[9]||(e[9]=o=>u.value=o),required:"",class:"wybor"},ne,512),[[g,u.value]]),t(a("input",{type:"numer","onUpdate:modelValue":e[10]||(e[10]=o=>x.value=o),placeholder:"Cena",class:"wybor"},null,512),[[n,x.value]])]),p(_,{onClick:e[11]||(e[11]=o=>A()),class:"mt-5",color:"#ebcc39"},{default:k(()=>[$("Dodaj ")]),_:1})]),_:1})])):C("",!0),(d(!0),M(W,null,G(B.value,o=>(d(),U(Z,{key:o.id},{default:k(()=>[a("div",null,[$(w(o.id)+" "+w(o.marka)+" "+w(o.model)+" ["+w(o.rejestracja)+"] ",1),o.czyZablokowany?C("",!0):(d(),U(_,{key:0,elevation:"0",onClick:F=>I(o.id),icon:"mdi-lock-open-outline"},null,8,["onClick"])),o.czyZablokowany?(d(),U(_,{key:1,elevation:"0",onClick:F=>I(o.id),icon:"mdi-lock-outline"},null,8,["onClick"])):C("",!0)])]),_:2},1024))),128))])])}}},de=T(se,[["__scopeId","data-v-5120803e"]]);export{de as default};
