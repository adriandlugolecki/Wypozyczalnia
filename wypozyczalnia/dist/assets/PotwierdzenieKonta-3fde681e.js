import{q as _,s as p,c as o,r as u,y as c,b as v,d as t,e as w,f as h,g as k,j as m,v as y,h as f,i as z,k as x}from"./index-75e11b7c.js";import{_ as K}from"./_plugin-vue_export-helper-c27b6911.js";const d=a=>(_("data-v-a0c88044"),a=a(),p(),a),b={class:"tlo"},I={class:"okno"},P=d(()=>o("h1",{class:"tytul"},"Wpisz kod",-1)),V=d(()=>o("div",null,"kod został wysłany na maila",-1)),j={__name:"PotwierdzenieKonta",setup(a){const s=u(),i=async()=>{try{var n=c.currentRoute.value.params.id,e=await v.patch(`/Autoryzacja/PotwierdzenieKonta/${n}/${s.value}`);e.data=="Aktywowano Konto"&&(t.tekst=e.data,t.show=!0,c.push("/"))}catch{t.tekst="Kod jest niepoprawny",t.error=!0,t.show=!0}};return(n,e)=>{const r=w("v-btn");return h(),k("div",b,[o("div",I,[P,o("div",null,[m(o("input",{class:"poleKod","onUpdate:modelValue":e[0]||(e[0]=l=>s.value=l),placeholder:"Wpisz kod"},null,512),[[y,s.value]])]),V,f(r,{onClick:i,color:"#ebcc39"},{default:z(()=>[x(" sprawdź")]),_:1})])])}}},N=K(j,[["__scopeId","data-v-a0c88044"]]);export{N as default};
