<?xml version="1.0"?>
<xsl:stylesheet	version="1.0"	xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="no"/>
  <xsl:param name="CurrentURL"></xsl:param>
  <xsl:param name="CurrentURLShort"></xsl:param>
  <xsl:param name="Home"></xsl:param>
  <xsl:param name="ID"></xsl:param>

  <xsl:template match="item">
    <table>
      <xsl:if test="descendant-or-self::*[@id=$ID]">
        <xsl:for-each select="preceding-sibling::*">
          <tr>
            <td>
				<small><a>
                  <xsl:attribute name="href">
                    <xsl:value-of select="$Home" />
                    <xsl:value-of select="@url"/>
                  </xsl:attribute>
                  <xsl:value-of select="@name"/>
                </a>
				</small>
			</td>
		</tr>
	</xsl:for-each>
	<xsl:for-each select="self::*">
		<tr>
			<td>
					<b>
					<small>
						<a>
                    <xsl:attribute name="href">
                      <xsl:value-of select="$Home" />
                      <xsl:value-of select="@url"/>
                    </xsl:attribute>
                    <xsl:value-of select="@name"/>
                  </a>

					</small>
					</b>
              <xsl:call-template name="buildChildren"></xsl:call-template>
            </td>
          </tr>
        </xsl:for-each>
        <xsl:for-each select="following-sibling::*">
          <tr>
            <td>
				<small>
				<a>
                  <xsl:attribute name="href">
                    <xsl:value-of select="$Home" />
                    <xsl:value-of select="@url"/>
                  </xsl:attribute>
                  <xsl:value-of select="@name"/>
                </a>
				</small>
			</td>
		</tr>
	</xsl:for-each>
</xsl:if>
</table>
</xsl:template>

<xsl:template name="buildChildren">
<table>
<xsl:for-each select="child::*">
	<xsl:if test="not(descendant-or-self::*[@id = $ID])">
		<tr>
			<td>
				<small>
				<a>
                  <xsl:attribute name="href">
                    <xsl:value-of select="$Home" />
                    <xsl:value-of select="@url"/>
                  </xsl:attribute>
                  <xsl:value-of select="@name"/>
                </a>
				</small>
			</td>
          </tr>
        </xsl:if>
        <xsl:if test="descendant-or-self::*[@id = $ID]">
          <tr>
            <td>
                <b>
					<small>
					<a>
                    <xsl:attribute name="href">
                      <xsl:value-of select="$Home" />
                      <xsl:value-of select="@url"/>
                    </xsl:attribute>
                    <xsl:value-of select="@name"/>
					</a>
					</small>
				</b>
              <xsl:call-template name="buildChildren"></xsl:call-template>
            </td>
          </tr>
        </xsl:if>
      </xsl:for-each>
    </table>
  </xsl:template>
</xsl:stylesheet>