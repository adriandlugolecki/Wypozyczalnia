import{q as C,s as k,c as e,r as v,o as w,y as z,B as b,e as p,f as a,g as r,h as t,F as y,n as B,t as f,i as h,k as m}from"./index-75e11b7c.js";import{_ as g}from"./_plugin-vue_export-helper-c27b6911.js";const n=c=>(C("data-v-86a52846"),c=c(),k(),c),x={class:"tlo"},E={class:"okno"},U=n(()=>e("h1",null,"Wybierz ubezpieczenie",-1)),S=n(()=>e("tr",null,[e("th",{width:"300px"},"Co obejmuje ubezpiecznie"),e("th",{width:"150px"},"Podstawowe"),e("th",{width:"150px",class:"gold2"},"Rozszerzone")],-1)),j=n(()=>e("td",null,"Standardowa polisa AC",-1)),I=n(()=>e("td",null,"Auto Zastępcze na terenie RP",-1)),R=n(()=>e("td",null,"Kradzież",-1)),K=n(()=>e("td",null,"Uszkodzenie Karoserii",-1)),N=n(()=>e("td",null,"Uszkodzenie Szyby",-1)),V=n(()=>e("td",null,"Uszkodzenie Opony",-1)),A=n(()=>e("td",null,"Opłaty administracyjne i koszt naprawy",-1)),F=n(()=>e("tr",null,[e("td",null,"Kaucja"),e("td",null,"2000 zł"),e("td",{class:"gold"},"1 zł")],-1)),L=n(()=>e("td",null,"Cena za 1 dzień",-1)),O=n(()=>e("td",null,null,-1)),P={__name:"RezerwacjaUbezpieczenie",setup(c){const d=v();w(async()=>{try{localStorage.setItem("auto",z.currentRoute.value.params.id);var s=await b.get("/Ubezpieczenie/ListaUbezpieczen");d.value=s.data,console.log(d.value)}catch(l){console.error("Błąd",l)}});const u=s=>{localStorage.setItem("ubezpieczenie",s),z.push("/podsumowanie")};return(s,l)=>{const o=p("v-icon"),_=p("v-btn");return a(),r("div",x,[e("div",E,[U,e("table",null,[S,e("tr",null,[j,e("td",null,[t(o,{icon:"mdi-check"})]),e("td",null,[t(o,{color:"#EBCC39",icon:"mdi-check"})])]),e("tr",null,[I,e("td",null,[t(o,{icon:"mdi-check"})]),e("td",null,[t(o,{icon:"mdi-check",color:"#EBCC39"})])]),e("tr",null,[R,e("td",null,[t(o,{icon:"mdi-close"})]),e("td",null,[t(o,{icon:"mdi-check",color:"#EBCC39"})])]),e("tr",null,[K,e("td",null,[t(o,{icon:"mdi-close"})]),e("td",null,[t(o,{icon:"mdi-check",color:"#EBCC39"})])]),e("tr",null,[N,e("td",null,[t(o,{icon:"mdi-close"})]),e("td",null,[t(o,{icon:"mdi-check",color:"#EBCC39"})])]),e("tr",null,[V,e("td",null,[t(o,{icon:"mdi-close"})]),e("td",null,[t(o,{icon:"mdi-check",color:"#EBCC39"})])]),e("tr",null,[A,e("td",null,[t(o,{icon:"mdi-close"})]),e("td",null,[t(o,{icon:"mdi-check",color:"#EBCC39"})])]),F,e("tr",null,[L,(a(!0),r(y,null,B(d.value,i=>(a(),r("td",{key:i.id},f(i.kwota)+" zł ",1))),128))]),e("tr",null,[O,e("td",null,[t(_,{onClick:l[0]||(l[0]=i=>u(1)),variant:"outlined",color:"#EBCC39"},{default:h(()=>[m(" wybierz ")]),_:1})]),e("td",null,[t(_,{onClick:l[1]||(l[1]=i=>u(2)),color:"#EBCC39"},{default:h(()=>[m(" wybierz ")]),_:1})])])])])])}}},q=g(P,[["__scopeId","data-v-86a52846"]]);export{q as default};
