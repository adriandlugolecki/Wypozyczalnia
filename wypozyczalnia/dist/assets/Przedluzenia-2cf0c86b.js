import{r as z,o as y,B as l,b as _,c as i,d,h as o,g as w,F as P,i as f,m as x,w as C,t as u,e as p,x as g,y as B,p as e}from"./index-9a356706.js";import{_ as I}from"./_plugin-vue_export-helper-c27b6911.js";const S=s=>(g("data-v-14188e66"),s=s(),B(),s),$={class:"tlo"},b={class:"okno"},j=S(()=>o("h1",{class:"tytul"},"Oczekujące przedłużenia",-1)),N={key:0,class:"tytul"},V={class:"element"},D={class:"info"},F={class:"przyciski"},L={__name:"Przedluzenia",setup(s){const c=z();y(async()=>{var t=await l.get("/Pracownik/DoPrzedluzenia");c.value=t.data});const v=async t=>{try{var n=await l.patch(`/Pracownik/ZaakceptujPrzedluzenie/${t}`);location.reload(),e.tekst=n.data,e.show=!0}catch(a){e.tekst=a.response.data,e.error=!0,e.show=!0}},k=async t=>{try{var n=await l.delete(`/Pracownik/UsunPrzedluzenie/${t}`);location.reload(),e.tekst=n.data,e.show=!0}catch{}};return(t,n)=>{const a=_("v-btn"),h=_("v-list-item");return i(),d("div",$,[o("div",b,[j,c.value==null?(i(),d("div",N,"Lista jest pusta")):w("",!0),(i(!0),d(P,null,f(c.value,r=>(i(),x(h,{key:c.value.id},{default:C(()=>[o("div",V,[o("div",D,u(r.wypozyczenieId)+"|"+u(r.kwota)+"zł",1),o("div",F,[p(a,{icon:"mdi-check",color:"green",onClick:m=>v(r.id)},null,8,["onClick"]),p(a,{icon:"mdi-delete",color:"red",onClick:m=>k(r.id)},null,8,["onClick"])])])]),_:2},1024))),128))])])}}},O=I(L,[["__scopeId","data-v-14188e66"]]);export{O as default};
