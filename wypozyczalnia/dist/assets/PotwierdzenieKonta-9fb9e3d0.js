import{r as p,b as _,c as u,d as v,h as o,k as w,l as h,e as k,w as m,s as c,a as y,p as t,j as x,x as z,y as f}from"./index-9a356706.js";import{_ as K}from"./_plugin-vue_export-helper-c27b6911.js";const d=a=>(z("data-v-a0c88044"),a=a(),f(),a),b={class:"tlo"},I={class:"okno"},P=d(()=>o("h1",{class:"tytul"},"Wpisz kod",-1)),V=d(()=>o("div",null,"kod został wysłany na maila",-1)),j={__name:"PotwierdzenieKonta",setup(a){const s=p(),i=async()=>{try{var n=c.currentRoute.value.params.id,e=await y.patch(`/Autoryzacja/PotwierdzenieKonta/${n}/${s.value}`);e.data=="Aktywowano Konto"&&(t.tekst=e.data,t.show=!0,c.push("/"))}catch{t.tekst="Kod jest niepoprawny",t.error=!0,t.show=!0}};return(n,e)=>{const r=_("v-btn");return u(),v("div",b,[o("div",I,[P,o("div",null,[w(o("input",{class:"poleKod","onUpdate:modelValue":e[0]||(e[0]=l=>s.value=l),placeholder:"Wpisz kod"},null,512),[[h,s.value]])]),V,k(r,{onClick:i,color:"#ebcc39"},{default:m(()=>[x(" sprawdź")]),_:1})])])}}},N=K(j,[["__scopeId","data-v-a0c88044"]]);export{N as default};
