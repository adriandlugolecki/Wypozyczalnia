import{q as z,s as y,c as o,r as w,o as f,B as l,d as e,e as _,f as i,g as d,m as P,F as C,n as g,p as x,i as B,t as u,h as p}from"./index-d81d64f3.js";import{_ as I}from"./_plugin-vue_export-helper-c27b6911.js";const S=s=>(z("data-v-14188e66"),s=s(),y(),s),$={class:"tlo"},j={class:"okno"},N=S(()=>o("h1",{class:"tytul"},"Oczekujące przedłużenia",-1)),V={key:0,class:"tytul"},b={class:"element"},D={class:"info"},F={class:"przyciski"},L={__name:"Przedluzenia",setup(s){const c=w();f(async()=>{var t=await l.get("/Pracownik/DoPrzedluzenia");c.value=t.data});const v=async t=>{try{var n=await l.patch(`/Pracownik/ZaakceptujPrzedluzenie/${t}`);location.reload(),e.tekst=n.data,e.show=!0}catch(a){e.tekst=a.response.data,e.error=!0,e.show=!0}},k=async t=>{try{var n=await l.delete(`/Pracownik/UsunPrzedluzenie/${t}`);location.reload(),e.tekst=n.data,e.show=!0}catch{}};return(t,n)=>{const a=_("v-btn"),h=_("v-list-item");return i(),d("div",$,[o("div",j,[N,c.value==null?(i(),d("div",V,"Lista jest pusta")):P("",!0),(i(!0),d(C,null,g(c.value,r=>(i(),x(h,{key:c.value.id},{default:B(()=>[o("div",b,[o("div",D,u(r.wypozyczenieId)+"|"+u(r.kwota)+"zł",1),o("div",F,[p(a,{icon:"mdi-check",color:"green",onClick:m=>v(r.id)},null,8,["onClick"]),p(a,{icon:"mdi-delete",color:"red",onClick:m=>k(r.id)},null,8,["onClick"])])])]),_:2},1024))),128))])])}}},M=I(L,[["__scopeId","data-v-14188e66"]]);export{M as default};