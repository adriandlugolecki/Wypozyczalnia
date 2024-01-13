import{r as c,o as Z,a as M,b,c as _,d as z,e as p,w as m,f as A,g as S,h as e,F as P,i as x,j as t,k as w,v as C,l as j,u as q,z as F,t as r,m as W,n as $,p as D}from"./index-9a356706.js";const H={class:"tlo"},G={class:"daty"},K={class:"datyElementy"},Q=e("label",null,"Odbiór",-1),X=["min","max"],Y=e("label",null,"Zwrot",-1),ee=["min"],le=e("option",{value:"0"},"25 lat i mniej",-1),ae=e("option",{value:"1"},"26 - 69 lat",-1),te=e("option",{value:"2"},"70 lat i więcej",-1),oe=[le,ae,te],ne={key:0,class:"o"},se=$('<div class="oNasTytul"><h1>Co nas wyróżnia</h1></div><div class="oNas"><div class="oNasLewo"><div><div class="oNasTytul"><h2>Samochody</h2></div><div>Nowe i zabytkowe</div></div><div><div class="oNasTytul"><h2>Rezygnacja</h2></div><div>Możliwość rezygnacji do 48 h przed datą odbioru</div></div></div><div class="oNasPrawo"><div><div class="oNasTytul"><h2>Płatność</h2></div><div>U nas płacisz przy odbiorze samochodu</div></div><div><div class="oNasTytul"><h2>Przedłużenia</h2></div><div>Jeżeli samochód nie będzie zarezerwowany przedłużymy ci go</div></div></div></div>',2),ie=[se],ue={key:1,class:"o"},de=e("div",{class:"oNasTytul"},[e("h1",null,"Nasze auta")],-1),ve={class:"oNas"},ce=e("div",null,null,-1),re=["src"],_e={key:2},ze={class:"filtrowanie"},he={class:"filtr"},ye=e("h2",null,"Filtry",-1),me=e("br",null,null,-1),we=e("option",{value:"null",selected:"",hidden:""},"Wybierz",-1),pe=e("option",{value:"0"},"Benzyna",-1),fe=e("option",{value:"1"},"Diesel",-1),ke=e("option",{value:null,checked:""},"Benzyna i Diesel",-1),be=[we,pe,fe,ke],Se=e("br",null,null,-1),je=e("option",{value:"null",selected:"",hidden:""},"Wybierz",-1),ge=e("option",{value:"0"},"Manual",-1),Ne=e("option",{value:"1"},"Automat",-1),Ce=e("option",{value:null,checked:""},"Manual i Automat",-1),De=[je,ge,Ne,Ce],Be={class:"listaSamochod"},Me={key:0,class:"samochod"},Pe=e("h2",{class:"nazwaSamochodu"},"Brak wolnych samochodów",-1),xe=[Pe],Ve={class:"samochod"},Re={class:"nazwaSamochodu"},Te={class:"infoSamochod"},Ue={class:"zdjecieSamochodu"},Ie=["src"],Ee={class:"oSamochodzie",style:{float:"left"}},Le=e("span",{class:"gold2"},"Rocznik:",-1),Je=e("br",null,null,-1),Oe=e("span",{class:"gold2"},"Rodzaj paliwa:",-1),Ze=e("br",null,null,-1),Ae=e("span",{class:"gold2"},"Rodzaj skrzyni:",-1),qe=e("br",null,null,-1),Fe=e("span",{class:"gold2"},"Liczba drzwi:",-1),We=e("br",null,null,-1),$e=e("span",{class:"gold2"},"Liczba miejsc:",-1),He={class:"cenaSamochodu"},Ge=e("br",null,null,-1),Ke=e("br",null,null,-1),Ye={__name:"Rezerwacja",setup(Qe){const B=c(),n=c(null),s=c(null),i=c(null),u=c(null),h=c(),y=c(),d=c([]),o=c([]),g=c(1),f=c(!1),N=c(0);Z(async()=>{try{var l=await M.get("/samochod");B.value=l.data,localStorage.getItem("data")&&localStorage.getItem("dataZakonczenia")&&(h.value=localStorage.getItem("data"),y.value=localStorage.getItem("dataZakonczenia"))}catch{}});const V=async()=>{if(y.value>h.value){var l=await M.get(`/samochod/wolnesamochody/${h.value}/${y.value}`);localStorage.setItem("data",h.value),localStorage.setItem("dataZakonczenia",y.value),localStorage.setItem("wiek",g.value),d.value=l.data,o.value=[...d.value],f.value=!0,N.value=Math.ceil(Math.abs(new Date(y.value)-new Date(h.value))/(1e3*3600*24))}else D.error=!0,D.tekst="Data zwrotu nie może być mniejsza od daty odbioru",D.show=!0},R=()=>{s.value!=null&&n.value!=null&&u.value!=null&&i.value!=null?o.value=d.value.filter(l=>l.cena>=n.value&&l.cena<=s.value&&l.rodzajSkrzyni==u.value&&l.rodzajPaliwa==i.value):s.value!=null&&n.value!=null&&u.value!=null?o.value=d.value.filter(l=>l.cena>=n.value&&l.cena<=s.value&&l.rodzajSkrzyni==u.value):s.value!=null&&n.value!=null&&i.value!=null?o.value=d.value.filter(l=>l.cena>=n.value&&l.cena<=s.value&&l.rodzajPaliwa==i.value):s.value!=null&&u.value!=null&&i.value!=null?o.value=d.value.filter(l=>l.cena<=s.value&&l.rodzajSkrzyni==u.value&&l.rodzajPaliwa==i.value):n.value!=null&&u.value!=null&&i.value!=null?o.value=d.value.filter(l=>l.cena>=n.value&&l.rodzajSkrzyni==u.value&&l.rodzajPaliwa==i.value):i.value!=null&&u.value!=null?o.value=d.value.filter(l=>l.rodzajPaliwa==i.value&&l.rodzajSkrzyni==u.value):n.value!=null&&s.value!=null?o.value=d.value.filter(l=>l.cena>=n.value&&l.cena<=s.value):i.value!=null?o.value=d.value.filter(l=>l.rodzajPaliwa==i.value):u.value!=null?o.value=d.value.filter(l=>l.rodzajSkrzyni==u.value):n.value!=null?o.value=d.value.filter(l=>l.cena>=n.value):s.value!=null?o.value=d.value.filter(l=>l.cena<=s.value):o.value=d.value},T=()=>{s.value=null,n.value=null,u.value=null,i.value=null,o.value=d.value},U=l=>l==0?"Manual":"Automat",I=l=>l==0?"Benzyna":"Diesel";return(l,v)=>{const k=b("v-btn"),E=b("v-form"),L=b("RouterLink"),J=b("v-list-item");return _(),z("div",H,[p(E,{onSubmit:A(V,["prevent"])},{default:m(()=>[e("div",G,[e("div",K,[e("div",null,[Q,w(e("input",{class:"kalendarz",type:"date","onUpdate:modelValue":v[0]||(v[0]=a=>h.value=a),min:new Date().getHours()>10?new Date(Date.now()+864e5).toJSON().slice(0,10):new Date().toJSON().slice(0,10),max:new Date(Date.now()+2592e6).toJSON().slice(0,10),onkeydown:"return false"},null,8,X),[[j,h.value]]),Y,w(e("input",{class:"kalendarz",type:"date","onUpdate:modelValue":v[1]||(v[1]=a=>y.value=a),min:new Date().toJSON().slice(0,10),onkeydown:"return false"},null,8,ee),[[j,y.value]])]),e("div",null,[e("div",null,[t(" wiek kierowcy "),w(e("select",{"onUpdate:modelValue":v[2]||(v[2]=a=>g.value=a),required:"",class:"wybor"},oe,512),[[C,g.value]]),p(k,{class:"mt-5 mb-5",type:"submit",color:"#EBCC39"},{default:m(()=>[t(" szukaj ")]),_:1})])])])])]),_:1},8,["onSubmit"]),f.value?S("",!0):(_(),z("div",ne,ie)),f.value?S("",!0):(_(),z("div",ue,[de,e("div",ve,[ce,(_(!0),z(P,null,x(B.value,a=>(_(),z("div",{class:"oNasSamochody",key:a.id},[e("img",{style:{"border-radius":"30px"},width:"150",src:q(F)+a.id+".png"},null,8,re),e("div",null,r(a.marka)+" "+r(a.model),1)]))),128))])])),f.value?(_(),z("div",_e,[e("div",ze,[e("div",he,[ye,e("div",null,[t(" Rodzaj paliwa "),me,w(e("select",{"onUpdate:modelValue":v[3]||(v[3]=a=>i.value=a),required:"",class:"wybor"},be,512),[[C,i.value]])]),e("div",null,[t(" Skrzynia biegów "),Se,w(e("select",{"onUpdate:modelValue":v[4]||(v[4]=a=>u.value=a),required:"",class:"wybor"},De,512),[[C,u.value]])]),e("div",null,[t(" Cena za dzień "),e("div",null,[t("od "),w(e("input",{type:"number",min:0,"onUpdate:modelValue":v[5]||(v[5]=a=>n.value=a),class:"wybor"},null,512),[[j,n.value]])]),e("div",null,[t("do "),w(e("input",{type:"number","onUpdate:modelValue":v[6]||(v[6]=a=>s.value=a),class:"wybor"},null,512),[[j,s.value]])])]),e("div",null,[p(k,{onClick:R,color:"#EBCC39"},{default:m(()=>[t(" filtruj ")]),_:1})]),p(k,{onClick:T,variant:"plant",color:"#EBCC39"},{default:m(()=>[t(" wyczyść ")]),_:1})])]),e("div",Be,[o.value.length==0?(_(),z("div",Me,xe)):S("",!0),(_(!0),z(P,null,x(o.value,a=>(_(),W(J,{key:a.id},{default:m(()=>[e("div",null,[e("div",Ve,[e("div",Re,[e("h3",null,r(a.marka)+" "+r(a.model),1)]),e("div",Te,[e("div",Ue,[e("img",{width:"150",style:{"border-radius":"100px"},src:"https://localhost:7122/Photos/"+a.id+".png"},null,8,Ie)]),e("div",Ee,[Le,t(" "+r(a.rocznik),1),Je,Oe,t(" "+r(I(a.rodzajPaliwa)),1),Ze,Ae,t(" "+r(U(a.rodzajSkrzyni)),1),qe,Fe,t(" "+r(a.liczbaDrzwi),1),We,$e,t(" "+r(a.liczbaMiejsc),1)]),e("div",He,[t(r(a.cena)+" zł za dzień",1),Ge,t(" "+r(a.cena*N.value)+" zł za "+r(N.value)+" dni",1),Ke,p(L,{to:"/rezerwacja/"+a.id+"/ubezpieczenia",custom:""},{default:m(({navigate:O})=>[p(k,{onClick:O,color:"#EBCC39"},{default:m(()=>[t("Wybieram")]),_:2},1032,["onClick"])]),_:2},1032,["to"])])])])])]),_:2},1024))),128))])])):S("",!0)])}}};export{Ye as default};
