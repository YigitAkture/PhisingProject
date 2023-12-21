//================LIMPA O CAMPO DO MODAL =======================
const limparCampo = () => {
  const fields = document.querySelectorAll(".field-reg");
  const fields2 = document.querySelectorAll(".field-login");
  fields2.forEach((field) => (field.value = ""));
  fields.forEach((field) => (field.value = ""));
};

  //================PERMITE PEGAR TODOS OS DADOS DE UM DETERMINADO BD DO LOCAL STORAGE =======================
  const getLocalStorage = () =>
  JSON.parse(localStorage.getItem("dbCliente")) ?? [];
  
  
  //================PERMITE ADICIONAR  DADOS A UM DETERMINADO BD DO LOCAL STORAGE =======================
  const setLocalStorage = (dbCliente) =>
    localStorage.setItem("dbCliente", JSON.stringify(dbCliente));
  
  
    //================LE TODOS OS CLIENTES E NO LOCAL STORAGE =======================
  
  const readClient = () => getLocalStorage();
  
  //================CRIA UM CLIENTE E SALVA NA LOCAL STORAGE =======================
  const createClient = (client) => {
    const dbCliente = getLocalStorage();
    dbCliente.push(client);
    setLocalStorage(dbCliente);
  };
  const isValidCadastro = () => {
    return document.getElementById("form-register").reportValidity();
  };
  const saveClient = () => {
    if (isValidCadastro()) {
      const client = {
        nome: document.getElementById("nameRegister").value,
        username: document.getElementById("usernameRegister").value,
        email: document.getElementById("emailRegister").value,
        password: document.getElementById("passwordRegister").value,
      };
      createClient(client);
      limparCampo();
      document.location.reload(true);
    }
  };
  
  const isValidLogin= () => {
    return document.getElementById("form-login").reportValidity();
  };
const validarLogin = () => {
  if(isValidLogin()){
    const userAtual = document.getElementById('usernameLogin').value
    const passAtual = document.getElementById('passwordLogin').value
   
    const contas = readClient()
    let r = []
    contas.forEach((conta, index)=>{

  
        if(userAtual != undefined && passAtual != undefined){
          if(userAtual == conta.username && passAtual == conta.password ){
            r = [{id:index, conta: conta, valido: true}]
          }
        }
    })
    return r
  }


}



//Tela de Login Area
const controlTelaLogin = () => {
  const telaLogin = document.querySelector('#telaLogin');
  const body = document.querySelector('body');
  const telaPrincipal = document.querySelector('#all-page');
  const btnEntrar = document.querySelector('#entrarLogin');




  btnEntrar.addEventListener('click', () => {
    if(validarLogin().length == 1){
      logar()
    }else{
      limparCampo()
      document.querySelector('#aviso-invalido').style.display = 'flex'
    }
    
  })

  const logar = () =>{
      telaLogin.style.display = 'none'
      telaPrincipal.style.display = 'flex'
      document.querySelector('#title-top').innerHTML= `Playlist for ${validarLogin()[0].conta.nome} `
      telaPrincipal.style.opacity = '1'
      body.style.overflowY = 'scroll';
  }

  const boxFormAnimation = () =>{
    const loginBtn = document.querySelector('.toRegister');
    const registerBtn = document.querySelector('.toLogin');
    const loginArea = document.querySelector('#login-area');
    const textBox = document.querySelector('.textBox');
    const registerArea = document.querySelector('#register-area');

    loginBtn.addEventListener('click', ()=> {
      registerArea.classList.remove('modoLogin')
      textBox.classList.remove('modoLogin')
      loginArea.classList.remove('modoLogin')
      registerArea.classList.add('modoRegistro')
      textBox.classList.add('modoRegistro')
      loginArea.classList.add('modoRegistro')
    })
    registerBtn.addEventListener('click', ()=> {
      registerArea.classList.remove('modoRegistro')
      textBox.classList.remove('modoRegistro')
      loginArea.classList.remove('modoRegistro')
      registerArea.classList.add('modoLogin')
      textBox.classList.add('modoLogin')
      loginArea.classList.add('modoLogin')
    })
  }
  boxFormAnimation()
}

controlTelaLogin()

document.getElementById("enviarRegister").addEventListener("click", saveClient);