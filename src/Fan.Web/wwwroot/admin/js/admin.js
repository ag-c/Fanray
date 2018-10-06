var app=new Vue({el:"#app",mixins:[adminMixin],data:()=>({drawer:null,snackbar:{show:!1,text:"",color:"",timeout:0}}),computed:{tok:function(){return document.querySelector("input[name=\"__RequestVerificationToken\"][type=\"hidden\"]").value},headers(){return{headers:{"XSRF-TOKEN":this.tok}}}},mounted(){this.initActiveNav()},methods:{initActiveNav(){var a=window.location.pathname;this.adminNavs.forEach(function(b){b.active=a.startsWith(b.url)})},logout:function(){axios.post("/home/logout",null,this.headers).then(function(){window.location.href="/"}).catch(function(){})},toast(a,b=3e3,c="silver"){this.snackbar.show=!0,this.snackbar.text=a,this.snackbar.color=c,this.snackbar.timeout=b},toastError(a,b=3e3){this.snackbar.show=!0,this.snackbar.text=a,this.snackbar.color="red",this.snackbar.timeout=b}}});
//# sourceMappingURL=admin.js.map