function toggleSignup() {
    document.getElementById("login-toggle").style.backgroundColor = "#0070C0";
    document.getElementById("login-form").style.backgroundColor = "#4c4e4f";

    document.getElementById("signup-toggle").style.backgroundColor = "#4c4e4f";
    
    document.getElementById("login-form").style.display = "none";
    document.getElementById("signup-form").style.display = "block";
    document.getElementById("signup-form").style.display = "block";
}

function toggleLogin() {
    document.getElementById("login-toggle").style.backgroundColor = "#4c4e4f";
    document.getElementById("signup-form").style.backgroundColor = "#4c4e4f";
   
    document.getElementById("signup-toggle").style.backgroundColor = " #0070C0";
    
    document.getElementById("signup-form").style.display = "none";
    document.getElementById("login-form").style.display = "block";
}
