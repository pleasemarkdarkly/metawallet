<?xml version="1.0"?>
<xsl:stylesheet	version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="no"/>
  <xsl:param name="CurrentURL"></xsl:param>
  <xsl:param name="CurrentURLShort"></xsl:param>
  <xsl:param name="Home"></xsl:param>
  <xsl:param name="ID"></xsl:param>

  <xsl:template match="item">
    <table>
        <xsl:for-each select="self::*">
          <tr>
            <td>
              <div class="LeftNav">
                <b>
                  <a>
                    <xsl:attribute name="href">
                      <xsl:value-of select="$Home" />
                      <xsl:value-of select="@url"/>
                    </xsl:attribute>
                    <xsl:value-of select="@name"/>
                  </a>
                </b>
              </div>
              <xsl:call-template name="buildChildren"></xsl:call-template>
            </td>
          </tr>
        </xsl:for-each>
    </table>
  </xsl:template>

  <xsl:template name="buildChildren">
    <table>
      <xsl:for-each select="child::*">
        <xsl:if test="not(descendant-or-self::*[@id = $ID])">
          <tr>
            <td>
              <div class="LeftNav">
                <a>
                  <xsl:attribute name="href">
                    <xsl:value-of select="$Home" />
                    <xsl:value-of select="@url"/>
                  </xsl:attribute>
                  <xsl:value-of select="@name"/>
                </a>
              </div>
            </td>
          </tr>
        </xsl:if>
        <xsl:if test="descendant-or-self::*[@id = $ID]">
          <tr>
            <td>
              <div class="LeftNav">
                <b>
                  <a>
                    <xsl:attribute name="href">
                      <xsl:value-of select="$Home" />
                      <xsl:value-of select="@url"/>
                    </xsl:attribute>
                    <xsl:value-of select="@name"/>
                  </a>
                </b>
              </div>
              <xsl:call-template name="buildChildren"></xsl:call-template>
            </td>
          </tr>
        </xsl:if>
      </xsl:for-each>
    </table>
  </xsl:template>
</xsl:stylesheet>