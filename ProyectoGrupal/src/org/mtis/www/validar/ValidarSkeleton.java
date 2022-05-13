
/**
 * ValidarSkeleton.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.6.3  Built on : Jun 27, 2015 (11:17:49 BST)
 */
    package org.mtis.www.validar;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;



/**
     *  ValidarSkeleton java skeleton for the axisService
     */
    public class ValidarSkeleton{
        
         
        /**
         * Auto generated method signature
         * 
                                     * @param validarCliente 
             * @return validarClienteResponse 
         */
        
                 public org.mtis.www.validar.ValidarClienteResponse validarCliente
                  (
                  org.mtis.www.validar.ValidarCliente validarCliente
                  )
            {
                	 Connection con = null;
                   	 ValidarClienteResponse cu=new ValidarClienteResponse();
                   	 boolean queryOk = false;
                   	 ResultSet s = null; 
                   	 try
                        {
                             Class.forName("com.mysql.cj.jdbc.Driver");
                             con = DriverManager.getConnection("jdbc:mysql://localhost:3306/companiarea?useUnicode=true&useJDBCCompliantTimezoneShift=true&useLegacyDatetimeCode=false&serverTimezone=UTC","root","adelfr.2000");
                           	 PreparedStatement stmt= con.prepareStatement("select *from cliente where dni='"+validarCliente.getDNI()+"';");
                             ResultSet result = stmt.executeQuery();
                             queryOk = result.next();
                             if(queryOk){
                            	 cu.setValido(true);
                             }
                             else{
                               	 cu.setValido(false);
                             }
                            con.close();
                        }
                        catch(Exception e)
                        {
                          
                        }
    					return cu;
        }
     
    }
    