
/**
 * Asiento.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis2 version: 1.6.3  Built on : Jun 27, 2015 (11:18:31 BST)
 */

            
                package org.mtis.www.vuelo;
            

            /**
            *  Asiento bean class
            */
            @SuppressWarnings({"unchecked","unused"})
        
        public  class Asiento
        implements org.apache.axis2.databinding.ADBBean{
        /* This type was generated from the piece of schema that had
                name = Asiento
                Namespace URI = http://www.mtis.org/Vuelo/
                Namespace Prefix = ns1
                */
            

                        /**
                        * field for Id
                        * This was an Attribute!
                        */

                        
                                    protected int localId ;
                                

                           /**
                           * Auto generated getter method
                           * @return int
                           */
                           public  int getId(){
                               return localId;
                           }

                           
                        
                            /**
                               * Auto generated setter method
                               * @param param Id
                               */
                               public void setId(int param){
                            
                                            this.localId=param;
                                       

                               }
                            

                        /**
                        * field for Fecha
                        * This was an Attribute!
                        */

                        
                                    protected java.util.Date localFecha ;
                                

                           /**
                           * Auto generated getter method
                           * @return java.util.Date
                           */
                           public  java.util.Date getFecha(){
                               return localFecha;
                           }

                           
                        
                            /**
                               * Auto generated setter method
                               * @param param Fecha
                               */
                               public void setFecha(java.util.Date param){
                            
                                            this.localFecha=param;
                                       

                               }
                            

                        /**
                        * field for LugarDestino
                        * This was an Attribute!
                        */

                        
                                    protected java.lang.String localLugarDestino ;
                                

                           /**
                           * Auto generated getter method
                           * @return java.lang.String
                           */
                           public  java.lang.String getLugarDestino(){
                               return localLugarDestino;
                           }

                           
                        
                            /**
                               * Auto generated setter method
                               * @param param LugarDestino
                               */
                               public void setLugarDestino(java.lang.String param){
                            
                                            this.localLugarDestino=param;
                                       

                               }
                            

                        /**
                        * field for Disponible
                        * This was an Attribute!
                        */

                        
                                    protected boolean localDisponible ;
                                

                           /**
                           * Auto generated getter method
                           * @return boolean
                           */
                           public  boolean getDisponible(){
                               return localDisponible;
                           }

                           
                        
                            /**
                               * Auto generated setter method
                               * @param param Disponible
                               */
                               public void setDisponible(boolean param){
                            
                                            this.localDisponible=param;
                                       

                               }
                            

                        /**
                        * field for Numero
                        * This was an Attribute!
                        */

                        
                                    protected int localNumero ;
                                

                           /**
                           * Auto generated getter method
                           * @return int
                           */
                           public  int getNumero(){
                               return localNumero;
                           }

                           
                        
                            /**
                               * Auto generated setter method
                               * @param param Numero
                               */
                               public void setNumero(int param){
                            
                                            this.localNumero=param;
                                       

                               }
                            

                        /**
                        * field for DNI
                        * This was an Attribute!
                        */

                        
                                    protected java.lang.String localDNI ;
                                

                           /**
                           * Auto generated getter method
                           * @return java.lang.String
                           */
                           public  java.lang.String getDNI(){
                               return localDNI;
                           }

                           
                        
                            /**
                               * Auto generated setter method
                               * @param param DNI
                               */
                               public void setDNI(java.lang.String param){
                            
                                            this.localDNI=param;
                                       

                               }
                            

     
     
        /**
        *
        * @param parentQName
        * @param factory
        * @return org.apache.axiom.om.OMElement
        */
       public org.apache.axiom.om.OMElement getOMElement (
               final javax.xml.namespace.QName parentQName,
               final org.apache.axiom.om.OMFactory factory) throws org.apache.axis2.databinding.ADBException{


        
               org.apache.axiom.om.OMDataSource dataSource =
                       new org.apache.axis2.databinding.ADBDataSource(this,parentQName);
               return factory.createOMElement(dataSource,parentQName);
            
        }

         public void serialize(final javax.xml.namespace.QName parentQName,
                                       javax.xml.stream.XMLStreamWriter xmlWriter)
                                throws javax.xml.stream.XMLStreamException, org.apache.axis2.databinding.ADBException{
                           serialize(parentQName,xmlWriter,false);
         }

         public void serialize(final javax.xml.namespace.QName parentQName,
                               javax.xml.stream.XMLStreamWriter xmlWriter,
                               boolean serializeType)
            throws javax.xml.stream.XMLStreamException, org.apache.axis2.databinding.ADBException{
            
                


                java.lang.String prefix = null;
                java.lang.String namespace = null;
                

                    prefix = parentQName.getPrefix();
                    namespace = parentQName.getNamespaceURI();
                    writeStartElement(prefix, namespace, parentQName.getLocalPart(), xmlWriter);
                
                  if (serializeType){
               

                   java.lang.String namespacePrefix = registerPrefix(xmlWriter,"http://www.mtis.org/Vuelo/");
                   if ((namespacePrefix != null) && (namespacePrefix.trim().length() > 0)){
                       writeAttribute("xsi","http://www.w3.org/2001/XMLSchema-instance","type",
                           namespacePrefix+":Asiento",
                           xmlWriter);
                   } else {
                       writeAttribute("xsi","http://www.w3.org/2001/XMLSchema-instance","type",
                           "Asiento",
                           xmlWriter);
                   }

               
                   }
               
                                                   if (localId!=java.lang.Integer.MIN_VALUE) {
                                               
                                                writeAttribute("",
                                                         "id",
                                                         org.apache.axis2.databinding.utils.ConverterUtil.convertToString(localId), xmlWriter);

                                            
                                      }
                                    
                                            if (localFecha != null){
                                        
                                                writeAttribute("",
                                                         "fecha",
                                                         org.apache.axis2.databinding.utils.ConverterUtil.convertToString(localFecha), xmlWriter);

                                            
                                      }
                                    
                                            if (localLugarDestino != null){
                                        
                                                writeAttribute("",
                                                         "lugarDestino",
                                                         org.apache.axis2.databinding.utils.ConverterUtil.convertToString(localLugarDestino), xmlWriter);

                                            
                                      }
                                    
                                                   if (true) {
                                               
                                                writeAttribute("",
                                                         "disponible",
                                                         org.apache.axis2.databinding.utils.ConverterUtil.convertToString(localDisponible), xmlWriter);

                                            
                                      }
                                    
                                                   if (localNumero!=java.lang.Integer.MIN_VALUE) {
                                               
                                                writeAttribute("",
                                                         "numero",
                                                         org.apache.axis2.databinding.utils.ConverterUtil.convertToString(localNumero), xmlWriter);

                                            
                                      }
                                    
                                            if (localDNI != null){
                                        
                                                writeAttribute("",
                                                         "DNI",
                                                         org.apache.axis2.databinding.utils.ConverterUtil.convertToString(localDNI), xmlWriter);

                                            
                                      }
                                    
                    xmlWriter.writeEndElement();
               

        }

        private static java.lang.String generatePrefix(java.lang.String namespace) {
            if(namespace.equals("http://www.mtis.org/Vuelo/")){
                return "ns1";
            }
            return org.apache.axis2.databinding.utils.BeanUtil.getUniquePrefix();
        }

        /**
         * Utility method to write an element start tag.
         */
        private void writeStartElement(java.lang.String prefix, java.lang.String namespace, java.lang.String localPart,
                                       javax.xml.stream.XMLStreamWriter xmlWriter) throws javax.xml.stream.XMLStreamException {
            java.lang.String writerPrefix = xmlWriter.getPrefix(namespace);
            if (writerPrefix != null) {
                xmlWriter.writeStartElement(namespace, localPart);
            } else {
                if (namespace.length() == 0) {
                    prefix = "";
                } else if (prefix == null) {
                    prefix = generatePrefix(namespace);
                }

                xmlWriter.writeStartElement(prefix, localPart, namespace);
                xmlWriter.writeNamespace(prefix, namespace);
                xmlWriter.setPrefix(prefix, namespace);
            }
        }
        
        /**
         * Util method to write an attribute with the ns prefix
         */
        private void writeAttribute(java.lang.String prefix,java.lang.String namespace,java.lang.String attName,
                                    java.lang.String attValue,javax.xml.stream.XMLStreamWriter xmlWriter) throws javax.xml.stream.XMLStreamException{
            if (xmlWriter.getPrefix(namespace) == null) {
                xmlWriter.writeNamespace(prefix, namespace);
                xmlWriter.setPrefix(prefix, namespace);
            }
            xmlWriter.writeAttribute(namespace,attName,attValue);
        }

        /**
         * Util method to write an attribute without the ns prefix
         */
        private void writeAttribute(java.lang.String namespace,java.lang.String attName,
                                    java.lang.String attValue,javax.xml.stream.XMLStreamWriter xmlWriter) throws javax.xml.stream.XMLStreamException{
            if (namespace.equals("")) {
                xmlWriter.writeAttribute(attName,attValue);
            } else {
                registerPrefix(xmlWriter, namespace);
                xmlWriter.writeAttribute(namespace,attName,attValue);
            }
        }


           /**
             * Util method to write an attribute without the ns prefix
             */
            private void writeQNameAttribute(java.lang.String namespace, java.lang.String attName,
                                             javax.xml.namespace.QName qname, javax.xml.stream.XMLStreamWriter xmlWriter) throws javax.xml.stream.XMLStreamException {

                java.lang.String attributeNamespace = qname.getNamespaceURI();
                java.lang.String attributePrefix = xmlWriter.getPrefix(attributeNamespace);
                if (attributePrefix == null) {
                    attributePrefix = registerPrefix(xmlWriter, attributeNamespace);
                }
                java.lang.String attributeValue;
                if (attributePrefix.trim().length() > 0) {
                    attributeValue = attributePrefix + ":" + qname.getLocalPart();
                } else {
                    attributeValue = qname.getLocalPart();
                }

                if (namespace.equals("")) {
                    xmlWriter.writeAttribute(attName, attributeValue);
                } else {
                    registerPrefix(xmlWriter, namespace);
                    xmlWriter.writeAttribute(namespace, attName, attributeValue);
                }
            }
        /**
         *  method to handle Qnames
         */

        private void writeQName(javax.xml.namespace.QName qname,
                                javax.xml.stream.XMLStreamWriter xmlWriter) throws javax.xml.stream.XMLStreamException {
            java.lang.String namespaceURI = qname.getNamespaceURI();
            if (namespaceURI != null) {
                java.lang.String prefix = xmlWriter.getPrefix(namespaceURI);
                if (prefix == null) {
                    prefix = generatePrefix(namespaceURI);
                    xmlWriter.writeNamespace(prefix, namespaceURI);
                    xmlWriter.setPrefix(prefix,namespaceURI);
                }

                if (prefix.trim().length() > 0){
                    xmlWriter.writeCharacters(prefix + ":" + org.apache.axis2.databinding.utils.ConverterUtil.convertToString(qname));
                } else {
                    // i.e this is the default namespace
                    xmlWriter.writeCharacters(org.apache.axis2.databinding.utils.ConverterUtil.convertToString(qname));
                }

            } else {
                xmlWriter.writeCharacters(org.apache.axis2.databinding.utils.ConverterUtil.convertToString(qname));
            }
        }

        private void writeQNames(javax.xml.namespace.QName[] qnames,
                                 javax.xml.stream.XMLStreamWriter xmlWriter) throws javax.xml.stream.XMLStreamException {

            if (qnames != null) {
                // we have to store this data until last moment since it is not possible to write any
                // namespace data after writing the charactor data
                java.lang.StringBuffer stringToWrite = new java.lang.StringBuffer();
                java.lang.String namespaceURI = null;
                java.lang.String prefix = null;

                for (int i = 0; i < qnames.length; i++) {
                    if (i > 0) {
                        stringToWrite.append(" ");
                    }
                    namespaceURI = qnames[i].getNamespaceURI();
                    if (namespaceURI != null) {
                        prefix = xmlWriter.getPrefix(namespaceURI);
                        if ((prefix == null) || (prefix.length() == 0)) {
                            prefix = generatePrefix(namespaceURI);
                            xmlWriter.writeNamespace(prefix, namespaceURI);
                            xmlWriter.setPrefix(prefix,namespaceURI);
                        }

                        if (prefix.trim().length() > 0){
                            stringToWrite.append(prefix).append(":").append(org.apache.axis2.databinding.utils.ConverterUtil.convertToString(qnames[i]));
                        } else {
                            stringToWrite.append(org.apache.axis2.databinding.utils.ConverterUtil.convertToString(qnames[i]));
                        }
                    } else {
                        stringToWrite.append(org.apache.axis2.databinding.utils.ConverterUtil.convertToString(qnames[i]));
                    }
                }
                xmlWriter.writeCharacters(stringToWrite.toString());
            }

        }


        /**
         * Register a namespace prefix
         */
        private java.lang.String registerPrefix(javax.xml.stream.XMLStreamWriter xmlWriter, java.lang.String namespace) throws javax.xml.stream.XMLStreamException {
            java.lang.String prefix = xmlWriter.getPrefix(namespace);
            if (prefix == null) {
                prefix = generatePrefix(namespace);
                javax.xml.namespace.NamespaceContext nsContext = xmlWriter.getNamespaceContext();
                while (true) {
                    java.lang.String uri = nsContext.getNamespaceURI(prefix);
                    if (uri == null || uri.length() == 0) {
                        break;
                    }
                    prefix = org.apache.axis2.databinding.utils.BeanUtil.getUniquePrefix();
                }
                xmlWriter.writeNamespace(prefix, namespace);
                xmlWriter.setPrefix(prefix, namespace);
            }
            return prefix;
        }


  
        /**
        * databinding method to get an XML representation of this object
        *
        */
        public javax.xml.stream.XMLStreamReader getPullParser(javax.xml.namespace.QName qName)
                    throws org.apache.axis2.databinding.ADBException{


        
                 java.util.ArrayList elementList = new java.util.ArrayList();
                 java.util.ArrayList attribList = new java.util.ArrayList();

                
                            attribList.add(
                            new javax.xml.namespace.QName("","id"));
                            
                                      attribList.add(org.apache.axis2.databinding.utils.ConverterUtil.convertToString(localId));
                                
                            attribList.add(
                            new javax.xml.namespace.QName("","fecha"));
                            
                                      attribList.add(org.apache.axis2.databinding.utils.ConverterUtil.convertToString(localFecha));
                                
                            attribList.add(
                            new javax.xml.namespace.QName("","lugarDestino"));
                            
                                      attribList.add(org.apache.axis2.databinding.utils.ConverterUtil.convertToString(localLugarDestino));
                                
                            attribList.add(
                            new javax.xml.namespace.QName("","disponible"));
                            
                                      attribList.add(org.apache.axis2.databinding.utils.ConverterUtil.convertToString(localDisponible));
                                
                            attribList.add(
                            new javax.xml.namespace.QName("","numero"));
                            
                                      attribList.add(org.apache.axis2.databinding.utils.ConverterUtil.convertToString(localNumero));
                                
                            attribList.add(
                            new javax.xml.namespace.QName("","DNI"));
                            
                                      attribList.add(org.apache.axis2.databinding.utils.ConverterUtil.convertToString(localDNI));
                                

                return new org.apache.axis2.databinding.utils.reader.ADBXMLStreamReaderImpl(qName, elementList.toArray(), attribList.toArray());
            
            

        }

  

     /**
      *  Factory class that keeps the parse method
      */
    public static class Factory{

        
        

        /**
        * static method to create the object
        * Precondition:  If this object is an element, the current or next start element starts this object and any intervening reader events are ignorable
        *                If this object is not an element, it is a complex type and the reader is at the event just after the outer start element
        * Postcondition: If this object is an element, the reader is positioned at its end element
        *                If this object is a complex type, the reader is positioned at the end element of its outer element
        */
        public static Asiento parse(javax.xml.stream.XMLStreamReader reader) throws java.lang.Exception{
            Asiento object =
                new Asiento();

            int event;
            java.lang.String nillableValue = null;
            java.lang.String prefix ="";
            java.lang.String namespaceuri ="";
            try {
                
                while (!reader.isStartElement() && !reader.isEndElement())
                    reader.next();

                
                if (reader.getAttributeValue("http://www.w3.org/2001/XMLSchema-instance","type")!=null){
                  java.lang.String fullTypeName = reader.getAttributeValue("http://www.w3.org/2001/XMLSchema-instance",
                        "type");
                  if (fullTypeName!=null){
                    java.lang.String nsPrefix = null;
                    if (fullTypeName.indexOf(":") > -1){
                        nsPrefix = fullTypeName.substring(0,fullTypeName.indexOf(":"));
                    }
                    nsPrefix = nsPrefix==null?"":nsPrefix;

                    java.lang.String type = fullTypeName.substring(fullTypeName.indexOf(":")+1);
                    
                            if (!"Asiento".equals(type)){
                                //find namespace for the prefix
                                java.lang.String nsUri = reader.getNamespaceContext().getNamespaceURI(nsPrefix);
                                return (Asiento)org.mtis.www.vuelo.ExtensionMapper.getTypeObject(
                                     nsUri,type,reader);
                              }
                        

                  }
                

                }

                

                
                // Note all attributes that were handled. Used to differ normal attributes
                // from anyAttributes.
                java.util.Vector handledAttributes = new java.util.Vector();
                

                
                    // handle attribute "id"
                    java.lang.String tempAttribId =
                        
                                reader.getAttributeValue(null,"id");
                            
                   if (tempAttribId!=null){
                         java.lang.String content = tempAttribId;
                        
                                                 object.setId(
                                                    org.apache.axis2.databinding.utils.ConverterUtil.convertToInt(tempAttribId));
                                            
                    } else {
                       
                                           object.setId(java.lang.Integer.MIN_VALUE);
                                       
                    }
                    handledAttributes.add("id");
                    
                    // handle attribute "fecha"
                    java.lang.String tempAttribFecha =
                        
                                reader.getAttributeValue(null,"fecha");
                            
                   if (tempAttribFecha!=null){
                         java.lang.String content = tempAttribFecha;
                        
                                                 object.setFecha(
                                                    org.apache.axis2.databinding.utils.ConverterUtil.convertToDate(tempAttribFecha));
                                            
                    } else {
                       
                    }
                    handledAttributes.add("fecha");
                    
                    // handle attribute "lugarDestino"
                    java.lang.String tempAttribLugarDestino =
                        
                                reader.getAttributeValue(null,"lugarDestino");
                            
                   if (tempAttribLugarDestino!=null){
                         java.lang.String content = tempAttribLugarDestino;
                        
                                                 object.setLugarDestino(
                                                    org.apache.axis2.databinding.utils.ConverterUtil.convertToString(tempAttribLugarDestino));
                                            
                    } else {
                       
                    }
                    handledAttributes.add("lugarDestino");
                    
                    // handle attribute "disponible"
                    java.lang.String tempAttribDisponible =
                        
                                reader.getAttributeValue(null,"disponible");
                            
                   if (tempAttribDisponible!=null){
                         java.lang.String content = tempAttribDisponible;
                        
                                                 object.setDisponible(
                                                    org.apache.axis2.databinding.utils.ConverterUtil.convertToBoolean(tempAttribDisponible));
                                            
                    } else {
                       
                    }
                    handledAttributes.add("disponible");
                    
                    // handle attribute "numero"
                    java.lang.String tempAttribNumero =
                        
                                reader.getAttributeValue(null,"numero");
                            
                   if (tempAttribNumero!=null){
                         java.lang.String content = tempAttribNumero;
                        
                                                 object.setNumero(
                                                    org.apache.axis2.databinding.utils.ConverterUtil.convertToInt(tempAttribNumero));
                                            
                    } else {
                       
                                           object.setNumero(java.lang.Integer.MIN_VALUE);
                                       
                    }
                    handledAttributes.add("numero");
                    
                    // handle attribute "DNI"
                    java.lang.String tempAttribDNI =
                        
                                reader.getAttributeValue(null,"DNI");
                            
                   if (tempAttribDNI!=null){
                         java.lang.String content = tempAttribDNI;
                        
                                                 object.setDNI(
                                                    org.apache.axis2.databinding.utils.ConverterUtil.convertToString(tempAttribDNI));
                                            
                    } else {
                       
                    }
                    handledAttributes.add("DNI");
                    
                    
                    reader.next();
                



            } catch (javax.xml.stream.XMLStreamException e) {
                throw new java.lang.Exception(e);
            }

            return object;
        }

        }//end of factory class

        

        }
           
    